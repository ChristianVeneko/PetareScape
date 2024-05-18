using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private static SaveManager instance;
    public static SaveManager Instance { get { return instance; } }
    public static string saveManagerTag = "SaveManager";

    public int coins;
    public int highScore;
    public int deathTimes;

    public int highScoreGame2;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Save()
    {
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.SetInt("DeathTimes", deathTimes);
    }

    public void saveGame2()
    {
        PlayerPrefs.SetInt("HighScoreGame2", highScoreGame2);
        PlayerPrefs.Save();
        //PlayerPrefs.SetInt("Coins", coins);
    }

    public void Load()
    {   
        coins = PlayerPrefs.GetInt("Coins", 0);
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        deathTimes = PlayerPrefs.GetInt("DeathTimes", 0);
        highScoreGame2 = PlayerPrefs.GetInt("HighScoreGame2", 0);
    }
}