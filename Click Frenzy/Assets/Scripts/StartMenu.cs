using System;
using Unity.VisualScripting;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    private void Awake()
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.GameObject().SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
