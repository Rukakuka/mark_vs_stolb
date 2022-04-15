using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public List<AudioClip> clips;

    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayAudioClip(string clipToPlay)
    {
        foreach (AudioClip clip in clips)
        {
            if (clip.name == clipToPlay)
            { 
                audioSource.clip = clip;
                if (!audioSource.isPlaying)
                    audioSource.Play();
            }
        }
    }
}