using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI textoScore;
    public int Score;

    public void SumaScore(int cantidad)
    {
        Score+=cantidad;
        textoScore.text = "Score: " + Score.ToString();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
