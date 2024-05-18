using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{

    private static SettingsManager instance;
    public static SettingsManager Instance { get { return instance; } }
    public bool musicOn = true;
    public bool soundOn = true;

    private void Awake()
    {

        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Load()
    {

        // Carga preferencias guardadas
        // Si no hay datos guardados, se quedan los valores por defecto
        musicOn = PlayerPrefs.GetInt("musicOn", 1) == 1;
        soundOn = PlayerPrefs.GetInt("soundOn", 1) == 1;

    }

    public void Save()
    {

        PlayerPrefs.SetInt("musicOn", musicOn ? 1 : 0);
        PlayerPrefs.SetInt("soundOn", soundOn ? 1 : 0);

        PlayerPrefs.Save();
    }

}