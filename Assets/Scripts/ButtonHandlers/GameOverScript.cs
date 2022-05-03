using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScript : MonoBehaviour
{
    public TextMeshProUGUI endGameText;
    public GameObject GameOverPanel;

    public static bool endgame = false;
    private void Start()
    {
        endGameText.enabled = false;
        GameOverPanel.SetActive(false);
    }
    void Update()
    {
        endGameText.enabled = false;
        GameOverPanel.SetActive(false);

        if (ScoreScript.Score == 0)
        {
            endgame = false;
            foreach (Light light in LightOffScript.lights)
                light.enabled = true;
        }
            

        if (ScoreScript.Score >= 1)
        {
            
            foreach (Light light in LightOffScript.lights)
                light.enabled = false;

            PlayerMovement.trForce = 0;
            PlayerMovement.rotForce = 0;
            PlayerMovement.jumpForce = 0;

            endGameText.enabled = true;
            GameOverPanel.SetActive(true);

            GameObject comp = GameObject.Find("AudioPlayer");
            AudioPlayer player = comp.GetComponent<AudioPlayer>();

            List<string> sounds = new List<string>();
            sounds.Add("malchik");
            sounds.Add("brb_phonk");

            System.Random rnd = new System.Random();
            int r = rnd.Next(sounds.Count);

            if (!endgame)
            {
                var players = FindObjectsOfType(typeof(AudioSource));

                foreach (AudioSource source in players)
                {
                    source.Stop();
                }

                if (!player.audioSource.isPlaying)
                    player.PlayAudioClip((string)sounds[r]);
            }
            
            endgame = true;
            //endGameText.enabled = true;
        }
    }
    public static void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ScoreScript.Score = 0;
    }
}