using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private CoinSound coinSound;
    public bool soundOn;


    private void Start()
    {
        soundOn = SettingsManager.Instance.soundOn;

    }

    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(coinSound.audioSource == null))
        {
            Debug.Log("playing");
            coinSound.playSound(soundOn);
        }
        gameObject.SetActive(false);
        GameManager2.Instance.coins++;
        Debug.Log(GameManager2.Instance.coins);
        GameManager2.Instance.score--;
    }


}
