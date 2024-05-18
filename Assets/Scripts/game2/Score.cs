using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager2.Instance.score++;
        GameManager2.Instance.IncreaseScore();
    }
}
