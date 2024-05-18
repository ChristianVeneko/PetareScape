using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour
{
    public InterstitialAds interstitialAd;
    public AdsInitializer ads;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void continuePlay()
    {
        GameManager2.Instance.ContinuePlay();
    }

    public void RestartGame()
    {
        ShowInterstitialMaybe();
    }

    public void homeButton()
    {
        GameManager2.Instance.SaveCoins();
        SceneLoadManager.Instance.LooadMenuScene();
    }

    void ShowInterstitialMaybe()
    {
        // Generar un número aleatorio entre 0 y 1
        float random = Random.Range(0.0f, 1.0f);

        // Si el número es menor a 0.3 (30%) mostrar el anuncio
        if (random < 0.3f)
        {
            interstitialAd.LoadAd();
            interstitialAd.ShowAd();
        }
        else
        {
            GameManager2.Instance.RestartGame();
        }
    }
}
