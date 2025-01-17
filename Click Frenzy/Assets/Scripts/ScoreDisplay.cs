using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _display;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _display.text = "Wow das Spiel funkt";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
