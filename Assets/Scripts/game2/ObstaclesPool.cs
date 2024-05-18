using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesPool : MonoBehaviour
{
    [SerializeField] private GameObject knifesPrefab;
    [SerializeField] private GameObject polarPrefab;
    [SerializeField] private GameObject zuliaPrefab;
    [SerializeField] private GameObject beersPrefab;
    [SerializeField] private float spawnTime = 0.5f;
    [SerializeField] private int poolSize = 5;
    [SerializeField] private float xSpawnPosition;
    [SerializeField] private float minYPosition;
    [SerializeField] private float maxYPosition;



    public float timeElapsed;
    public int obstacleCount;
    private GameObject[] obstacles;

    private bool scoreReached30 = false;
    void Start()
    {
        if (StoreManager.Instance.isZulia)
        {
            beersPrefab = zuliaPrefab;
        }
        else
        {
            beersPrefab = polarPrefab;
        }

        obstacles = new GameObject[poolSize];
        instanciateObstacles(knifesPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= spawnTime && (!GameManager2.Instance.isGameOver && GameManager2.Instance.gameStarted))
        {
            SpawnObstacle();
        } 
    }

    public void ResetObstacles()
    {
        destroyObjects();
        if (scoreReached30)
        {
            instanciateObstacles(beersPrefab);

        }
        else
        {

            instanciateObstacles(knifesPrefab);
        }
        obstacleCount = 0;
        timeElapsed = spawnTime;
    }

    public void destroyObjects()
    {
        for (int i = 0; i < poolSize; i++)
        {
            Destroy(obstacles[i]);
        }
    }

    public void ChangeObstacle()
    {
        GameManager2.Instance.scoreReached30 = true;
        scoreReached30 = true;
        ResetObstacles();
    }

    public void instanciateObstacles(GameObject prefab)
    {
        for (int i = 0; i < poolSize; i++)
        {
             obstacles[i] = Instantiate(prefab);
            obstacles[i].SetActive(false);
        }
    }

    public void SpawnObstacle()
    {
        timeElapsed = 0f;
        float random = Random.value;
        float ySpawnPosition = Random.Range(minYPosition, maxYPosition);
        Vector2 spawnPosition = new Vector2(xSpawnPosition, ySpawnPosition);
        obstacles[obstacleCount].transform.position = spawnPosition;
        GameObject coin = obstacles[obstacleCount].transform.Find("Coin").gameObject;

        if (!obstacles[obstacleCount].activeSelf)
        {
          obstacles[obstacleCount].SetActive(true);
        }

        if (random < 0.5)
        {
            coin.SetActive(true);
        }
        obstacleCount++;

        if(obstacleCount == poolSize)
        {
            obstacleCount = 0;
        }
    }
}
