using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasketHit : MonoBehaviour
{
    private float scorePos;
    private int scoreCounter;
    [SerializeField] private GameObject ball;
    [SerializeField] public Collider2D c;

    private void Awake()
    {
        c.GetComponent<Collider2D>();
        ball.GetComponent<GameObject>();
        c.enabled = false;
        scoreCounter = 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
            scoreCounter++;
            Debug.Log(scoreCounter);
    }
}
