using System;
using System.Collections;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AutoClickerUpgrade : MonoBehaviour, Upgrade
{
    public static GameObject gameManagerObject = null;
    public static GameManager gameManager = null;
    public UpgradeManager upgradeManager = null;
    private int _flatScore = 0;
    private double _scoreMultiplier = 1;

    void Awake()
    {
        gameManagerObject = GameObject.Find("Game Manager");
    }
    
    void Start()
    {
        gameManager = gameManagerObject.GetComponent<GameManager>();
        if (gameManager != null)
        {
            Debug.Log("Game manager instance obtained!");
        }

        upgradeManager = GameObject.Find("Upgrade Manager").GetComponent<UpgradeManager>();
    }

    public void OnBuy()
    {
        upgradeManager.UpgradeCollection.Add(this);
        StartCoroutine(Click());
    }
    
    IEnumerator Click()
    {
        gameManager.IncreaseScore(Convert.ToInt32((_flatScore + upgradeManager.FlatScoreBonus) * (_scoreMultiplier + upgradeManager.ScoreMultiplierBonus)));
        yield return new WaitForSeconds(1);
    }
}