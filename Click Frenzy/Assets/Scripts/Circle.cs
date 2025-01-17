    using System;
    using UnityEngine;
    using UnityEngine.UI;

    public class Circle : MonoBehaviour
    {
        [SerializeField]
        public static GameObject gameManagerObject = null;
        public static GameManager gameManager = null;
        private int flatScore = 1;
        private double scoreMultiplier = 1.00;
        private void Awake()
        {
            gameManagerObject = GameObject.Find("GameManager");
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
    }
