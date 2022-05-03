using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    public int Health = 30;
    public Text HealthText;
    public GameObject GameOverPanel;

    static public int collectedItems = 0;
    static public int Score = 0;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI ItemsAmountText;
    void Start()
    {
        ScoreText = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        DisplayScore();

    }

    void DisplayScore()
    {
        ScoreText.text = "Столбов собрано: " + Score.ToString() + "/1";
    }
}
