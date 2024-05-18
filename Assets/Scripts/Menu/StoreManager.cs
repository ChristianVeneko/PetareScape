using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    private static StoreManager instance;
    public static StoreManager Instance { get { return instance; } }

    private const string isFirstTimeKey = "IsFirstTime"; // Clave para la variable en PlayerPrefs.  

    public bool isMercedes = false;
    public bool isCareMuerto = false;
    public bool plusHearth = false;
    public bool isZulia = false;

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
    void Start()
    {
        // Verificar si es la primera vez que se inicia el juego.
        if (!PlayerPrefs.HasKey(isFirstTimeKey))
        {
            // Si no existe la clave en PlayerPrefs (primera vez que se inicia el juego),
            // configurarla en false (o cualquier otro valor predeterminado que desees).
            PlayerPrefs.SetInt(isFirstTimeKey, 0);
            PlayerPrefs.Save();
        }
        Load();
    }

    public void Load()
    {

        // Carga preferencias guardadas
        // Si no hay datos guardados, se quedan los valores por defecto
        plusHearth = PlayerPrefs.GetInt("plusHearth", 0) == 1;
        isCareMuerto = PlayerPrefs.GetInt("isCareMuerto", 0) == 1;
        isZulia = PlayerPrefs.GetInt("isZulia", 0) == 1;
        isMercedes = PlayerPrefs.GetInt("isMercedes", 0) == 1;

    }

    public void Save()
    {

        PlayerPrefs.SetInt("plusHearth", plusHearth ? 1 : 0);
        PlayerPrefs.SetInt("isCareMuerto", isCareMuerto ? 1 : 0);
        PlayerPrefs.SetInt("isZulia", isZulia ? 1 : 0);
        PlayerPrefs.SetInt("isMercedes", isMercedes ? 1 : 0);

        PlayerPrefs.Save();
    }
}
