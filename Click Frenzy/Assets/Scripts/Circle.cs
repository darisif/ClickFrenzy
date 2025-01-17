    using System;
    using DefaultNamespace;
    using UnityEngine;
    using UnityEngine.UI;

    public class Circle : MonoBehaviour
    {
        public static Circle instance { get; set; } = null;
        [SerializeField]
        public static GameObject gameManagerObject = null;
        public static GameManager gameManager = null;
        private int flatScore = 1;
        private double scoreMultiplier = 1.00;
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
            //if(Input.GetMouseButton(0))
            {
                gameManager.IncreaseScore(Convert.ToInt32(flatScore * scoreMultiplier));
            }
        }

        public void UpgradeCircle(EUpgradeType upgradeType, double value)
        {
            switch (upgradeType)
            {
                case EUpgradeType.FlatScore:
                    flatScore += Convert.ToInt32(value);
                    Debug.Log($"{flatScore}");
                    break;
                case EUpgradeType.ScoreMult:
                    scoreMultiplier += value;
                    Debug.Log($"{scoreMultiplier}");
                    break;
                default:
                    throw new ArgumentException("Upgrade type is not permitted!");
            }
        }
    }
