using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public SaveManager saveManager;
    public SettingsManager settingsManager;
    public SettingsMenu settingsMenu;
    public TextMeshProUGUI coinsText;
    public MusicManager musicManager;

    private void Awake()
    {
        settingsManager = GameObject.FindWithTag("SettingsManager").GetComponent<SettingsManager>();
        saveManager.Load();
        settingsManager.Load();
        Configure();
        coinsText.text = saveManager.coins.ToString();
    }

    private void Configure()
    {
        if (settingsManager.musicOn)
        {
            musicManager.UnmuteMusic();
            settingsMenu.changeMusicSprite(true);
        }
        else
        {
            musicManager.MuteMusic();
            settingsMenu.changeMusicSprite(false);
        }

        if (settingsManager.soundOn)
        {
            settingsMenu.ChangeSoundSprite(true);
        }
        else
        {
            settingsMenu.ChangeSoundSprite(false);
        }
    }
}
