using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]private GameObject bullet;
    [SerializeField] private GameObject yonaiker;
    [SerializeField] private GameObject chiave;
    [SerializeField] private GameObject careMuerto;

    [SerializeField] public GameObject BackgroundPetare;

    public float maxX;
    public Transform spawnPoint;
    public float spawnRate;
    public float yonaikerSpawnRate;
    public float chiaveSpawnRate;
    public float careMuertoSpawnRate;

    public GameObject scoreText1;
    public GameObject pauseButton;
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI actualScore;
    public TextMeshProUGUI highScore;

    public AdsInitializer ads;

    public int coins = 0;
    public TextMeshProUGUI coinsText;

    public int score = 0;

    public MusicManager musicManager;
    SettingsManager settingsManager;

    public bool gameOverState = false;

    public bool isMercedes = false;

    private void Start()
    {
        isMercedes = StoreManager.Instance.isMercedes;

        if (isMercedes)
        {
            BackgroundPetare.SetActive(false);
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

        StartSpawning(spawnRate, "Bullet");
        scoreText1.SetActive(true);
        pauseButton.SetActive(true);
    }


    private void LoadData()
    {
        SaveManager.Instance.Load();
        settingsManager = GameObject.FindWithTag("SettingsManager").GetComponent<SettingsManager>();
        settingsManager.Load();
    }

    public void saveHighScore()
    {
        if(score > SaveManager.Instance.highScore)
        {
            SaveManager.Instance.highScore = score;
            SaveManager.Instance.Save();
            
        }
    }

    public void saveCoins()
    {
        SaveManager.Instance.coins += coins;
        SaveManager.Instance.Save();
    }

    public void GameOver()
    {
        gameOverState = true;
        CalculateCoins();
        ads.InitializeAds();
        actualScore.text = score.ToString();
        coinsText.text = "+ " + coins.ToString();
        highScore.text = SaveManager.Instance.highScore.ToString();
        saveHighScore();
    }

    public void CalculateCoins()
    {
        if (score < 100)
        {
            coins = score / 10;
        }
        else if (score < 500)
        {
            coins = 10 + (score - 100) / 20;
        }
        else if (score < 1000)
        {
            coins = 10 + (400 / 20) + (score - 500) / 50;
        }
        else
        {
            coins = 10 + (400 / 20) + (500 / 50) + (score - 1000) / 100;
        }

        coins =  Mathf.RoundToInt(coins);
    }

    private void SpawnBullet()
    {
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);
        Quaternion rotation = Quaternion.Euler(0, 0, -90);
        Instantiate(bullet, spawnPos, rotation);
    }

    private void SpawnYonaiker()
    {
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);
        Quaternion rotation = Quaternion.Euler(0, 0, 0);
        Instantiate(yonaiker, spawnPos, rotation);

    }

    private void SpawnChiave()
    {
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);
        Quaternion rotation = Quaternion.Euler(0, 0, 0);
        Instantiate(chiave, spawnPos, rotation);
        

    }

    private void SpawnCaremuerto()
    {
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);
        Quaternion rotation = Quaternion.Euler(0, 0, 0);
        Instantiate(careMuerto, spawnPos, rotation);
    }

    private void StartSpawning(float rate, string objType)
    {   
        if(objType == "Bullet")
        {
           InvokeRepeating("SpawnBullet", 0.5f, rate);

        }else if(objType == "Yonaiker")
        {
           InvokeRepeating("SpawnYonaiker", 0.5f, rate);
        }else if(objType == "Chiave")
        {
           InvokeRepeating("SpawnChiave", 0.5f, rate);
        }else if(objType == "Caremuerto")
        {
            InvokeRepeating("SpawnCaremuerto", 0.5f, rate);
        }
    }

    private void startSpawnYonaiker()
    {
        CancelInvoke("SpawnBullet");
        CancelInvoke("SpawnYonaiker");
        StartSpawning(0.7f, "Bullet");
        StartSpawning(yonaikerSpawnRate, "Yonaiker");
    }

    private void startSpawnChiave()
    {
        CancelInvoke("SpawnBullet");
        CancelInvoke("SpawnYonaiker");
        CancelInvoke("SpawnChiave");
        StartSpawning(0.8f, "Bullet");
        StartSpawning(yonaikerSpawnRate + 0.2f, "Yonaiker");
        StartSpawning(chiaveSpawnRate, "Chiave");
    }

    public void StartSpawnCaremuerto()
    {
        CancelInvoke("SpawnBullet");
        CancelInvoke("SpawnYonaiker");
        CancelInvoke("SpawnChiave");
        CancelInvoke("SpawnCaremuerto");
        StartSpawning(0.8f, "Bullet");
        StartSpawning(yonaikerSpawnRate + 0.2f, "Yonaiker");
        StartSpawning(chiaveSpawnRate, "Chiave");
        StartSpawning(careMuertoSpawnRate, "Caremuerto");
    }

    public void ScoreTextChanger()
    {
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(score == 30)
        {
            Invoke("startSpawnYonaiker", 1f);
        }

        if (score == 60)
        {
            Invoke("startSpawnChiave", 1f);
        }

        if(score == 100)
        {
            Invoke("StartSpawnCaremuerto", 1f);
        }
    }

    void OnApplicationQuit()
    {
        if (gameOverState)
        {
            CalculateCoins();
            saveHighScore();
            saveCoins();
        }
        
    }
}
