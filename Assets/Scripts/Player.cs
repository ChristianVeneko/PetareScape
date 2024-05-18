using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed;
    public int health = 3;
    public GameObject hearth1;
    public GameObject hearth2;
    public GameObject hearth3;
    public GameObject hearth4;
    public float immunityTime;
    private float immunityCounter;

    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameManager gameManager;
    Rigidbody2D rb;

    public bool isPlusHerth = false;

    void Start()
    {
        isPlusHerth = StoreManager.Instance.plusHearth;
        
        if (isPlusHerth)
        {
            health = 4;
            hearth4.SetActive(true);
        }
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (immunityCounter > 0)
        {
            immunityCounter -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (touchPos.x < 0)
            {
                rb.AddForce(Vector2.left * moveSpeed);
            }
            else
            {
                rb.AddForce(Vector2.right * moveSpeed);
            }

        }
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void reciveDamage()
    {
        if (immunityCounter <= 0)
        {
            if (health == 4 && isPlusHerth)
            {
                hearth4.SetActive(false);
            }
            else if (health == 3)
            {
                hearth3.SetActive(false);
            }
            else if (health == 2)
            {
                hearth2.SetActive(false);
            }

            health--;
            immunityCounter = immunityTime;
        }        
    }

    public void SetHealth(int health)
    {

        this.health = health;

    }
    public void Pause()
    {
        gameOverMenu.SetActive(true);
        gameManager.GameOver();
        Time.timeScale = 0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Bullet")
        {
            if(health <= 1)
            {
                hearth1.SetActive(false);
                Pause();
            }
            else
            {
                reciveDamage();
            }

        }
    }
}
