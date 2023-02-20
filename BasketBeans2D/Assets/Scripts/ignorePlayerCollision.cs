using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnorePlayerCollision : MonoBehaviour
{
    public Collider2D Player;
    public Collider2D other;

    private void Start()
    {
        
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player = GetComponent<Collider2D>();
            other = GetComponent<Collider2D>();
        }
    }
}