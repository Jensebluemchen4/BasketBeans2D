using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    [SerializeField] public Rigidbody2D ball;
    public int scoreCounter;
    private bool hitFromTop;

    private void Awake()
    {
        scoreCounter = 0;
        ball.GetComponent<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ball.velocity.y < 0)
        {
            hitFromTop = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (ball.velocity.y < 0 && hitFromTop == true)
        {
            scoreCounter++;
        }
        hitFromTop = false;
    }
}
