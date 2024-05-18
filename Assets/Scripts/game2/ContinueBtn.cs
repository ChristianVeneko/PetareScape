using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueBtn : MonoBehaviour
{
    public Button continueButton;
    [SerializeField] RewardedAdsButton2 adBtn;
    [SerializeField] GameOverButtons gameOverButtons;

    private void Start()
    {
        continueButton.interactable = false;
    }
    public void continueGame()
    {
        adBtn.LoadAd() ;
        continueButton.interactable = false;
        gameOverButtons.continuePlay();
    }
}
