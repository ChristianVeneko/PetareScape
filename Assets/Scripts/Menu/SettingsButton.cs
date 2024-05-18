using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    public GameObject playButton;
    public GameObject settingsFrame;
    void Start()
    {
        
    }

    public void settings()
    {
        playButton.SetActive(false);
        gameObject.SetActive(false);
        settingsFrame.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
