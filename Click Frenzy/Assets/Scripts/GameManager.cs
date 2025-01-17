using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting; //Allows us to use Lists. 

/// <summary>
/// Provided by an Unity Tutorial on Singletons.
/// Things related to running the game go here!
/// </summary>
public class GameManager : MonoBehaviour
{
    //Static instance of GameManager which allows it to be accessed by any other script.
    public static GameManager instance = null;

    public GameObject StartMenu; 

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);    

        //Sets this to not be destroyed when reloading scene
        //To be clear for others: this does not mean JUST loading the current scene, but also any new ones.
        DontDestroyOnLoad(gameObject);

        StartMenu = GameObject.Find("StartMenu").gameObject;
    }

    private void Start()
    {
    }

    //Update is called every frame.
    void Update()
    {
        StartMenu.SetActive(true);
    }
}