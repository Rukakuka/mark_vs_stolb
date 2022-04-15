using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static System.Random;

public class CollisionScore : MonoBehaviour
{

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Stolb")
        {
            if (!GameOverScript.endgame)
            {
                GameObject comp = GameObject.Find("AudioPlayer");
                AudioPlayer player = comp.GetComponent<AudioPlayer>();

                List<string> sounds = new List<string>();
                sounds.Add("hana_marku");
                sounds.Add("bah_bah");
                sounds.Add("dorifto");
                sounds.Add("otsechka");
                sounds.Add("pedalirovanie");

                System.Random rnd = new System.Random();
                int r = rnd.Next(0, sounds.Count);
                if (!player.audioSource.isPlaying)
                    player.PlayAudioClip((string)sounds[r]);
            }
            ScoreScript.Score += 1;
        }
    }
}