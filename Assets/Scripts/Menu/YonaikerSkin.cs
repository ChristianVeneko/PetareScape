using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class YonaikerSkin : MonoBehaviour
{
    [SerializeField] public GameObject buyButton;
    [SerializeField] public GameObject selectButton;
    [SerializeField] TextMeshProUGUI selectText;
    public bool isBought;
    public bool isSelected;


    void Start()
    {
        
    }

    public void SelectButtonAction()
    {
        if (!isSelected)
        {
            selectText.text = "SELECTED";
            isSelected = true;
            return;
        }
        else
        {
            selectText.text = "SELECT";
            isSelected = false;
            return;
        }
    }

    public void BuyButtonAction()
    {
        UnActiveBuyButton();
    }

    public void UnActiveBuyButton()
    {
        buyButton.SetActive(false);
        selectButton.SetActive(true);
    }
}
