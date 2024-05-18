using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    void Start()
    {
    }

    public void MuteMusic()
    {
        GameObject[] musicObjects = GameObject.FindGameObjectsWithTag("Music");

        foreach (GameObject obj in musicObjects)
        {
            AudioSource audio = obj.GetComponent<AudioSource>();
            if (audio)
            {
                audio.mute = true;
            }
        }
    }

    public void UnmuteMusic()
    {
        GameObject[] musicObjects = GameObject.FindGameObjectsWithTag("Music");

        foreach (GameObject obj in musicObjects)
        {
            AudioSource audio = obj.GetComponent<AudioSource>();
            if (audio)
            {
                audio.mute = false;
            }
        }
    }
}