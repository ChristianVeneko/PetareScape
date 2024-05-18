using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{
    [SerializeField] private float upForce = 350f;

    private bool isDead;
    private Rigidbody2D playerRb;

    private static PlayerHead instance;
    public static PlayerHead Instance { get { return instance; } }

    private void Awake()
    {

        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerRb.gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            playerRb.gravityScale = 0.5f;
            Flap();

        }
    }

    public void ResetPlayerPosition()
    {
        playerRb.position = new Vector2(-0.101f, 0f);
        isDead = false;

    }

    private void Flap()
    {
        playerRb.velocity = Vector2.zero;
        playerRb.AddForce(Vector2.up * upForce);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager2.Instance.GameOver();
        isDead = true;
    }
}
