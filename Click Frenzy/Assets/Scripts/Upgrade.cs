using System;
using DefaultNamespace;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    private Circle _circle;
    [SerializeField]
    public static GameObject gameManagerObject = null;
    public static GameManager gameManager = null;

    private void Awake()
    {
        gameManagerObject = GameObject.Find("Game Manager");
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
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gameManager.DecreaseScore(10))
            {
                _circle.UpgradeCircle(EUpgradeType.ScoreMult, 1.7);
                gameObject.SetActive(false);
            }
        }
    }
}
