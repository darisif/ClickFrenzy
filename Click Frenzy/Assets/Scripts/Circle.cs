    using System;
    using DefaultNamespace;
    using Unity.VisualScripting;
    using UnityEngine;
    using UnityEngine.UI;
    using Random = UnityEngine.Random;

    public class Circle : MonoBehaviour
    {
        public static Circle instance { get; set; } = null;
        private Rigidbody2D _circleBody = null;
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

            _circleBody = gameObject.GetComponent<Rigidbody2D>();
            _circleBody.gravityScale = 0f;
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
            this.gameObject.SetActive(false);
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
                gameObject.transform.localScale -= gameObject.transform.localScale * 0.005f;
                gameManager.IncreaseScore(Convert.ToInt32(flatScore * scoreMultiplier));
            }
        }
        
        /// <summary>
        /// EnableCircleMovement adds a random Force to the circle, causing it to move.
        /// This is a random number between 0 and 50, and is clamped based on how high the user's current score is.
        /// </summary>
        public void EnableCircleMovement()
        {
            float var1 = Math.Clamp(Random.Range(0f, 50f), (gameManager.Score / 25 * 0.2f), (gameManager.Score / 10 * 0.2f));
            if (Random.value > 0.5f)
            {
                var1 = var1 * -1;
            }
            float var2 = Math.Clamp(Random.Range(0f, 50f), (gameManager.Score / 25 * 0.2f), (gameManager.Score / 10 * 0.2f));
            if (Random.value > 0.5f)
            {
                var2 = var2 * -1;
            }
            _circleBody.AddForce(new Vector2(var1, var2));
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
