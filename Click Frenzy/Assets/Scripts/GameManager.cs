using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    //Static instance of GameManager which allows it to be accessed by any other script.
    public static GameManager instance { get; set; } = null;

    public GameObject startMenu;
    private TextMeshProUGUI _scoreDisplayText;
    private TextMeshProUGUI _timerDisplayText;
    private Circle _circle;
    private Rigidbody2D _circleBody;
    private GameObject _clikupgrade;
    private GameObject _multupgrade;
    private double _timer = 0;
    public bool GameStarted { get; private set; } = false;
    public double Score { get; private set; } = 0;

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this      
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)
        {
            Debug.Log("Not a singleton instance now, is it?");
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);    
        }

        startMenu = GameObject.Find("Start Menu").gameObject;
        _scoreDisplayText = GameObject.Find("/Score Display/Score Display Text").GetComponent<TextMeshProUGUI>();
        _timerDisplayText = GameObject.Find("/Timer Display/Timer Display Text").GetComponent<TextMeshProUGUI>();
        _circle = GameObject.Find("Circle").GetComponent<Circle>();
        _circleBody = _circle.gameObject.GetComponent<Rigidbody2D>();
        _clikupgrade = GameObject.Find("AutoClickUpgrade");
        _multupgrade = GameObject.Find("ClickerMultUpgrade");
    }

    private void Start()
    {
        startMenu.SetActive(true);
    }

    //Update is called every frame.
    void Update()
    {
        if (GameStarted)
        {
            _timer = Math.Clamp((_timer -= 1 * Time.deltaTime), 0, 120);
            //Cuts the fractional part only for text display
            _timerDisplayText.text = $"Time left: {Math.Truncate(_timer)}";
            if (_timer == 0)
            {
                GameStarted = false;
                _timerDisplayText.text = "Game over!";
                _scoreDisplayText.text = $"Final score: {Score}";
                _circle.gameObject.SetActive(false);
                _multupgrade.SetActive(false);
                _clikupgrade.SetActive(false);
            }
        }
    }

    public void IncreaseScore(double value)
    {
        Score += value;
        _scoreDisplayText.text = $"{Math.Truncate(Score)}";
        if (Score >= 100)
        {
            _circle.EnableCircleMovement();
        }
        Debug.Log($"Score is {Score}");
    }

    public bool DecreaseScore(int value)
    {   
        if (Score >= value)
        {
            Score -= value;
            _scoreDisplayText.text = $"{Math.Truncate(Score)}";
            Debug.Log($"Score is {Score}");
            return true;
        }
        return false;
    }

    public bool StartGame()
    {
        GameStarted = true;
        if (GameStarted)
        {
            _circle.gameObject.SetActive(true);
            _multupgrade.SetActive(true);
            _clikupgrade.SetActive(true);
            _timer = 120;
            return true;
        }
        return false;
    }
}