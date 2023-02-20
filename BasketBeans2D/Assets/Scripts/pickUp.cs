using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private Transform hold;
    public GameObject ball;
    [SerializeField] private Rigidbody2D ballrb;
    [SerializeField] private float maxMouseRadius = 10f;
    [SerializeField] private float maxPickUpDist = 2f;
    [SerializeField] private float throwForce = 25f;
    public bool inHand = false;
    private float distance;
    
    Vector3 mousePosition;

    private void Start()
    {
        Hold();
        inHand = true;
    }


    void Update()
    {
        FollowMouse();

        Physics2D.IgnoreLayerCollision(0, 3);

        //Check Distance between ball and player
        try
        {
            distance = Vector2.Distance(ball.transform.position, transform.position);
        }
        catch (Exception) { }

        Vector3 throwDir = mousePosition - transform.position;

        //Check if ball is not in hand and nearby
        if (Input.GetKeyDown(KeyCode.Mouse0) && inHand == false && distance <= maxPickUpDist)
        {
            Hold();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && inHand == true)
        {
            Throw(throwDir);
        }
    }

    //Method to pick up ball
    void Hold()
    {
        ball.GetComponent<Rigidbody2D>().isKinematic = true;
        ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);


        //Move object to transform of object "hold" and set player to Parent
        ball.transform.position = hold.position;
        ball.transform.SetParent(transform);
        ballrb.freezeRotation = true;

        inHand = true;
    }

    //Method to throw ball
    void Throw(Vector3 throwDir)
    {
        ball.GetComponent<Rigidbody2D>().isKinematic = false;
        ball.transform.SetParent(null);

        ballrb.AddForce((Vector3.ClampMagnitude((throwDir), maxMouseRadius) * throwForce));
        ballrb.freezeRotation = false;

        inHand = false;
    }

    void FollowMouse()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
    }
}


