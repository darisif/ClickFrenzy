using System;
using DefaultNamespace;
using UnityEngine;

public class ClickMultUpgrade : MonoBehaviour, IUpgrade
{
    private Circle _circle;
    private AudioSource _clickSound = null;
    public static GameObject gameManagerObject = null;
    public static GameManager gameManager = null;

    private void Awake()
    {
        gameManagerObject = GameObject.Find("Game Manager");
        _clickSound = gameObject.GetComponent<AudioSource>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = gameManagerObject.GetComponent<GameManager>();
        if (gameManager != null)
        {
            Debug.Log("Game manager instance obtained!");
        }
        _circle = GameObject.Find("Circle").GetComponent<Circle>();
        if (_circle != null)
        {
            Debug.Log("Circle instance obtained!");
        }
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _clickSound.Play();
            Debug.Log("clicking upgrade!");
            if (gameManager.DecreaseScore(20))
            {
                OnBuy();
            }
        }
    }   

    public void OnBuy()
    {
        Debug.Log("upgrade paid!");
        _circle.UpgradeCircle(EUpgradeType.ScoreMult, 2.0);
    }
}
