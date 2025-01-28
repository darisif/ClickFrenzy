using System;
using System.Collections;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AutoClickerUpgrade : MonoBehaviour, IUpgrade
{
    public static GameObject gameManagerObject = null;
    public static GameManager gameManager = null;
    private AudioSource _clickSound = null;
    public UpgradeManager upgradeManager = null;
    [SerializeField] private GameObject _prefab = null;
    
    void Awake()
    {
        gameManagerObject = GameObject.Find("Game Manager");
        _clickSound = gameObject.GetComponent<AudioSource>();
    }
    
    void Start()
    {
        gameManager = gameManagerObject.GetComponent<GameManager>();
        if (gameManager != null)
        {
            Debug.Log("Game manager instance obtained!");
        }
        gameObject.SetActive(false);
        upgradeManager = GameObject.Find("Upgrade Manager").GetComponent<UpgradeManager>();
        if (upgradeManager != null)
        {
            Debug.Log("UM instance obtained!");
            if (upgradeManager.UpgradeCollection != null)
            {
                Debug.Log("UMC instance obtained!");
            }
        }
    }


    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _clickSound.Play();
            Debug.Log("clicking upgrade!");
            if (gameManager.DecreaseScore(100))
            {
                OnBuy();
            }
        }
    }   

    public void OnBuy()
    {
        Instantiate(_prefab);
        AutoClickerClickerAction a = new AutoClickerClickerAction();
        upgradeManager.UpgradeCollection.Add(a);    
    }
    
}