using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{

    [SerializeField]private float distance;
    [SerializeField] private Transform hold;
    [SerializeField] private GameObject ball;
    private bool inHand = false;
    private float maxDist = 3f;


    void Update()
    {
        Physics2D.IgnoreLayerCollision(0, 3);

        //Check Distance between ball and player
        float distance = Vector2.Distance(ball.transform.position, transform.position);

        //Check if ball is not in hand and nearby
        if (Input.GetKeyDown(KeyCode.Mouse0) && inHand == false && distance <= maxDist)
        {
            PickUp();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && inHand == true)
        {
            Throw();
        }
    }

    //Method to pick up ball
    void PickUp()
    {
        ball.GetComponent<Rigidbody2D>().isKinematic = true;
        ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        ball.GetComponent<Collider2D>().enabled = false;

        //Move object to transform of object "hold" and set player to Parent
        ball.transform.position = hold.position;
        ball.transform.SetParent(transform);

        inHand = true;
    }

    //Method to throw ball
    void Throw()
    {
        ball.GetComponent<Rigidbody2D>().isKinematic = false;
        ball.transform.SetParent(null);
        ball.GetComponent<Collider2D>().enabled = true;

        inHand = false;
    }
}


