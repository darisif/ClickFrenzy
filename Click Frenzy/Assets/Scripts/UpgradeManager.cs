using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance { get; set; } = null;
    public List<Upgrade> UpgradeCollection { get; set; } = new List<Upgrade>(){};
    public int FlatScoreBonus { get; set; } = 1;
    public double ScoreMultiplierBonus { get; set; } = 1.00;

    private void Awake()
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
    }

    public void DeleteUpgrades()
    {
        UpgradeCollection.Clear();
    }
}
