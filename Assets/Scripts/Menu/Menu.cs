using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    [SerializeField] private GameObject selectGamePanel;
    [SerializeField] private GameObject playObjectBtn;
    [SerializeField] private GameObject settingsObjectBtn;

    public void play()
    {
        settingsObjectBtn.SetActive(false);
        playObjectBtn.SetActive(false);
        selectGamePanel.SetActive(true);
    }
    void Start()
    {
        
    }

    public void Return()
    {
        settingsObjectBtn.SetActive(true);
        playObjectBtn.SetActive(true);
        selectGamePanel.SetActive(false);
    }
    public void Game1()
    {
        SceneLoadManager.Instance.LoadGame1Scene();
    }

    public void game2()
    {
        SceneLoadManager.Instance.LoadGame2Scene();
    }
  
}
