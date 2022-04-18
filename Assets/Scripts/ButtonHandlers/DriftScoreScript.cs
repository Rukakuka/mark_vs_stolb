using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static System.Math;

public class DriftScoreScript : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    
    // Start is called before the first frame update
    void Update()
    {
        DisplayScore();

    }

    void DisplayScore()
    {
        if ((float)(Sqrt(Pow(PlayerMovement.rb.velocity.x, 2) + Pow(PlayerMovement.rb.velocity.z, 2))) > 0.5)
        {
            ScoreText.text = "Drift score: " + TrailRender.DriftScore.ToString();
        }
    }
}

