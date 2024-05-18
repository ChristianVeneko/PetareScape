using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    private static SceneLoadManager instance;
    public static SceneLoadManager Instance { get { return instance; } }

    [SerializeField] private Animator transitionAnimator;

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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }


    public void LooadMenuScene()
    {
        StartCoroutine(SceneLoad(0));
    }
    public void LoadGame1Scene()
    {
        StartCoroutine(SceneLoad(1));
    }

    public void LoadGame2Scene()
    {
        StartCoroutine(SceneLoad(2));
    }

    public IEnumerator SceneLoad(int sceneIndex)
    {
        transitionAnimator.SetTrigger("StartTransition");

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneIndex);
    }
}
