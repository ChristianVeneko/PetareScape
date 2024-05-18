using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    GameManager gameManager;
    public float destroyPosition = -3.33f;
    public AudioSource  audioSource;
    private bool audioPlayed = false;

    public bool soundOn;
    private void Start()
    {
        soundOn = SettingsManager.Instance.soundOn;
        gameManager = GameObject.FindWithTag("GameManager1").GetComponent<GameManager>();
        if (!(audioSource == null))
        {
            audioSource.GetComponent<AudioSource>();
        }
            
        
    }

    void Update()
    {
       
    }
    
    public void playSound()
    {
        if (soundOn)
        {
            audioSource.mute = false;
            audioSource.Play();
        }
        else
        {
            audioSource.mute = true;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.y <= destroyPosition && !audioPlayed)
        {
            if (!(audioSource == null))
            {
                playSound();
            }
            audioPlayed = true;
            gameManager.score++;
            gameManager.ScoreTextChanger();
        }

        if (transform.position.y < destroyPosition - 40f && audioPlayed)
        {
            Destroy(gameObject);
        }
    }
}
