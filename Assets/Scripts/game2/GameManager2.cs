using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager2 : MonoBehaviour
{
    [SerializeField] public GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private ObstaclesPool obstaclesPool;
    [SerializeField] private Scroll scroll;
    [SerializeField] private Scroll scroll2;

    [SerializeField] private AdsInitializer ads;
    [SerializeField] public GameObject tapToStartText;
    [SerializeField] TextMeshProUGUI actualScoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI coinsEarnedText;

    [SerializeField] private MusicManager musicManager;
    [SerializeField] SettingsManager settingsManager;

    public Vector2 spawnPosition;
    [SerializeField] private GameObject careMuerto;
    [SerializeField] private GameObject skeletonHead;


    private static GameManager2 instance;
    public static GameManager2 Instance { get { return instance; } }

    public bool isGameOver;
    public bool gameStarted = false;
    public int score;
    public int coins;

    public bool isCareMuerto = false;

    public bool scoreReached30 = false;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }   
    private void Start()
    {
        isCareMuerto = StoreManager.Instance.isCareMuerto;

        if (isCareMuerto)
        {
            SetPlayer(careMuerto);
        }
        else
        {
            SetPlayer(skeletonHead);
        }

        LoadData();
        if (settingsManager.musicOn)
        {
            musicManager.UnmuteMusic();
        }
        else
        {
            musicManager.MuteMusic();
        }
    }

    private void SetPlayer(GameObject prefab)
    {
        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }
    private void LoadData()
    {
        settingsManager = GameObject.FindWithTag("SettingsManager").GetComponent<SettingsManager>();
        settingsManager.Load();
        SaveManager.Instance.Load();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !gameStarted)
        {
            tapToStartText.SetActive(false);
            gameStarted = true;
        }
        if(score == 30 && scoreReached30 == false)
        {
            obstaclesPool.ChangeObstacle();
        }
    }


    public void ContinuePlay()
    {
        scroll.SetVelocity();
        scroll2.SetVelocity();
        gameOverPanel.SetActive(false);
        obstaclesPool.ResetObstacles();
        isGameOver = false;
        PlayerHead.Instance.ResetPlayerPosition();
    }

    public void SaveHighScore()
    {
        if (score > SaveManager.Instance.highScoreGame2)
        {
            SaveManager.Instance.highScoreGame2 = score;
            SaveManager.Instance.saveGame2();
        }
        return;
    }

    public void SaveCoins()
    {
        SaveManager.Instance.coins += coins;
        SaveManager.Instance.Save();
    }

    public void ShowScore()
    {
        actualScoreText.text = score.ToString();
        highScoreText.text = SaveManager.Instance.highScoreGame2.ToString();
    }

    public void ShowCoins()
    {
        coinsEarnedText.text = " + " + coins.ToString();
    }


    public void GameOver()
    {
        SaveManager.Instance.Load();
        SaveHighScore();
        ShowScore();
        ShowCoins();
        isGameOver = true;
        gameOverPanel.SetActive(true);

    }

    public void RestartGame()
    {
        SaveCoins();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void IncreaseScore()
    {
        scoreText.text = score.ToString();
    }

    void OnApplicationQuit()
    {
        if (isGameOver)
        {
            SaveHighScore();
            SaveCoins();
        }

    }
}
