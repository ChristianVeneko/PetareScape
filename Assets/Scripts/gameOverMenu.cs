using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOverMenu : MonoBehaviour
{
    public Player player;
    [SerializeField] GameObject gameOver;
    public GameObject hearth;
    public RewardedAdsButton adBtn;
    public GameObject hearth2;
    public GameObject hearth3;
    public Button continueButton;
    public string typeBtn;

    public GameManager gameManager;

    private void Awake()
    {
        if(typeBtn == "continue")
        {
            continueButton.interactable = false;
        }
    }


    public void continueBtn()
    {
        player.SetHealth(3);
        hearth.SetActive(true);
        hearth2.SetActive(true);
        hearth3.SetActive(true);
        gameOver.SetActive(false);
        Time.timeScale = 1f;
        adBtn.LoadAd();
        continueButton.interactable = false;
        gameManager.gameOverState = false;

    }

    public void restartBtn()
    {
        gameManager.saveCoins();
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void menuBtn()
    {
        Time.timeScale = 1f;
        gameManager.saveCoins();
        SceneLoadManager.Instance.LooadMenuScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
