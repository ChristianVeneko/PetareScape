using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSound : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;

    private void Start()
    {
        if (!(audioSource == null))
        {
            audioSource.GetComponent<AudioSource>();
            audioSource.clip = audioClip;
        }


    }

    public void playSound(bool soundOn)
    {
        Debug.Log(audioSource.mute);
        if (soundOn)
        {
            Debug.Log("Play");
            audioSource.mute = false;
            audioSource.Play();
        }
        else
        {
            Debug.Log("Mute");
            audioSource.mute = true;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
