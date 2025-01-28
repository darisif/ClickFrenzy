using UnityEngine;

namespace DefaultNamespace
{
    public class AutoClickerClickerAction : MonoBehaviour, IUpgrade
    {
        private static GameObject gameManagerObject = null;
        public static GameManager gameManager = null;
        private int _flatScore = 0;
        private double _scoreMultiplier = 1;
        public UpgradeManager upgradeManager = null;
        
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
        private void FixedUpdate()
        {
            if (!gameManager.GameStarted)
            {
                Destroy(this);
            }
            gameManager.IncreaseScore((Time.fixedDeltaTime * (_flatScore + upgradeManager.FlatScoreBonus) * (_scoreMultiplier + upgradeManager.ScoreMultiplierBonus)));
        }

        public void OnBuy()
        {
            throw new System.NotImplementedException();
        }
    }
}