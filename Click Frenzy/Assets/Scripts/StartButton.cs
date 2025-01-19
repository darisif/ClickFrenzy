using System;
using UnityEngine;

public class StartButton : MonoBehaviour
{
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameManager.StartGame();
            gameObject.GetComponentInParent<Transform>().gameObject.SetActive(false);
        }
    }
}
