using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreMenu : MonoBehaviour
{
    [SerializeField] private GameObject buyBtn1;
    [SerializeField] private GameObject buyBtn2;
    [SerializeField] private GameObject buyBtn3;
    [SerializeField] private GameObject buyBtn4;

    [SerializeField] private GameObject noMoneyPanel;
    [SerializeField] private TextMeshProUGUI coinsText;
    void Start()
    {
        if (StoreManager.Instance.plusHearth)
        {
            buyBtn1.SetActive(false);
        }

        if (StoreManager.Instance.isMercedes)
        {
            buyBtn4.SetActive(false);
        }

        if (StoreManager.Instance.isCareMuerto)
        {
            buyBtn2.SetActive(false);
        }

        if (StoreManager.Instance.isZulia)
        {
            buyBtn3.SetActive(false);
        }
    }
    

    public void BuyHearth()
    {
        const int price = 500;
        if(SaveManager.Instance.coins >= price)
        {
            buyBtn1.SetActive(false);
            SaveManager.Instance.coins = SaveManager.Instance.coins - price;
            SaveManager.Instance.Save();
            StoreManager.Instance.plusHearth = true;
            StoreManager.Instance.Save();
            StoreManager.Instance.Load();
            ChangeCoinsText();
        }
        else
        {
            SetAlert();
        }
        
    }

    public void BuyCaremuertoHead()
    {
        const int price = 200;
        if(SaveManager.Instance.coins >= price)
        {
            buyBtn2.SetActive(false);
            SaveManager.Instance.coins = SaveManager.Instance.coins - price;
            SaveManager.Instance.Save();
            StoreManager.Instance.isCareMuerto = true;
            StoreManager.Instance.Save();
            StoreManager.Instance.Load();
            ChangeCoinsText();
        }
        else
        {
            SetAlert();
        }

    }

    public void BuyZulia()
    {
        const int price = 300;
        if (SaveManager.Instance.coins >= price)
        {
            buyBtn3.SetActive(false);
            SaveManager.Instance.coins = SaveManager.Instance.coins - price;
            SaveManager.Instance.Save();
            StoreManager.Instance.isZulia = true;
            StoreManager.Instance.Save();
            StoreManager.Instance.Load();
            ChangeCoinsText();
        }
        else
        {
            SetAlert();
        }

    }

    public void BuyMercedes()
    {
        const int price = 200;
        if (SaveManager.Instance.coins >= price)
        {
            buyBtn4.SetActive(false);
            SaveManager.Instance.coins = SaveManager.Instance.coins - 2;
            SaveManager.Instance.Save();
            StoreManager.Instance.isMercedes = true;
            StoreManager.Instance.Save();
            StoreManager.Instance.Load();
            ChangeCoinsText();
        }
        else
        {
            SetAlert();
        }

    }

    public void SetAlert()
    {
        noMoneyPanel.SetActive(true);
    }

    public void QuitAlert()
    {
        noMoneyPanel.SetActive(false);
    }

    public void ChangeCoinsText()
    {
        coinsText.text = SaveManager.Instance.coins.ToString();
    }
}
