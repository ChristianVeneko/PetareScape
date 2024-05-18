using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreButtons : MonoBehaviour
{
    [SerializeField] private StoreMenu storeMenu;
    [SerializeField] private GameObject storePanel;
    public void PlusHearthBtn()
    {
        storeMenu.BuyHearth();
    }

    public void CareMuertoBtn()
    {
        storeMenu.BuyCaremuertoHead();
    }

    public void ZuliaBeerBtn()
    {
        storeMenu.BuyZulia();
    }

    public void MercedesBtn()
    {
        storeMenu.BuyMercedes();
    }

    public void QuitAlert()
    {
        storeMenu.QuitAlert();
    }

    public void StoreBtn()
    {
        storePanel.SetActive(true);
    }

    public void MenuBtn()
    {
        storePanel.SetActive(false);
    }
}
