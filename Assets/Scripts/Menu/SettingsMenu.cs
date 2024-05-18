using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public Button soundButton;
    public Button musicButton;

    public Sprite muteMusicSprite;
    public Sprite musicSprite;

    public Sprite soundSprite;
    public Sprite muteSoundSprite;

    public TextMeshProUGUI soundValue;
    public TextMeshProUGUI musicValue;

    public MusicManager audioManager;

    public GameObject settingsFrame;
    public GameObject playButton;
    public GameObject settingsButton;

    public string objType;

    public bool musicOn;
    public bool soundOn;
    void Start()
    {
        if(objType == "sound")
        {
            if (SettingsManager.Instance.soundOn)
            {
                ChangeSoundSprite(true);
            }
            else
            {
                ChangeSoundSprite(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SoundButton()
    {
        SettingsManager.Instance.Load();
        soundOn = SettingsManager.Instance.soundOn;
        if (soundOn == false)
        {
            SettingsManager.Instance.soundOn = true;
            Debug.Log(SettingsManager.Instance.soundOn);
            SettingsManager.Instance.Save();
            ChangeSoundSprite(true);
        }
        else
        {
            SettingsManager.Instance.soundOn = false;
            SettingsManager.Instance.Save();
            ChangeSoundSprite(false);
        }
        
    }

    public void home()
    {
        settingsFrame.SetActive(false);
        playButton.SetActive(true);
        settingsButton.SetActive(true);
    }

    public void MusicButton()
    {
        SettingsManager.Instance.Load();
        musicOn = SettingsManager.Instance.musicOn;

        if (musicOn == true)
        {
            SettingsManager.Instance.musicOn = false;
            changeMusicSprite(false);
            audioManager.MuteMusic();
        }
        else
        {
            SettingsManager.Instance.musicOn = true;
            changeMusicSprite(true);
            audioManager.UnmuteMusic();
        }

        SettingsManager.Instance.Save();
        
    }

    public void changeMusicSprite(bool state)
    {
        if (state)
        {
            Debug.Log("uy");
            musicButton.image.sprite = musicSprite;
            musicValue.text = "On";

        }
        else
        {
            musicButton.image.sprite = muteMusicSprite;
            musicValue.text = "Off";
        }
    }

    public void ChangeSoundSprite(bool state)
    {
        if (state)
        {
            soundButton.image.sprite = soundSprite;
            soundValue.text = "On";

        }
        else
        {
            soundButton.image.sprite = muteSoundSprite;
            soundValue.text = "Off";
        }
    }


}
