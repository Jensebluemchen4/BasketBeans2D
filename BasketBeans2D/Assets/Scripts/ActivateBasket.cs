using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBasket : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    BasketHit hit;

    private void Awake()
    {
        ball.GetComponent<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit.c.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        hit.c.enabled = false;
    }
}
