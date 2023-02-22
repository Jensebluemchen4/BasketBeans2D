using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private Transform hold;
    public GameObject ball;
    [SerializeField] private Rigidbody2D ballrb;
    [SerializeField] private float maxPickUpDist = 2f;
    [SerializeField] private float maxAutoDist;
    [SerializeField] private float throwForce = 25f;
    
    
    
    [SerializeField] private float maxMouseRadius = 10f;
    public float mouseRadius;


    private Rigidbody2D player;
    public bool inHand = true;
    private float playerDistanceToObject;
    public Player pm;
    private Vector2 throwPos;


    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        if (inHand)
        Hold();
    }

    void Update()
    {

        throwPos = new Vector2(pm.mousePosition.x, pm.mousePosition.y);
        if (throwPos.magnitude < maxMouseRadius)
        {
            mouseRadius = throwPos.magnitude;
        }
        else
        {
            mouseRadius = maxMouseRadius;
        }

        if (Time.timeScale == 1)
        {

            Physics2D.IgnoreLayerCollision(0, 3);

            //Check Distance between ball and player
            try
            {
                playerDistanceToObject = Vector2.Distance(ball.transform.position, transform.position);

                //Check if ball is not in hand and nearby
                if (Input.GetKeyDown(KeyCode.Mouse0) && inHand == false && playerDistanceToObject < maxPickUpDist)
                {
                    Hold();
                }
                else if (Input.GetKeyDown(KeyCode.E) && inHand == false)
                {
                    Hold();
                }
                else if (Input.GetKeyDown(KeyCode.Mouse0) && inHand == true)
                {
                    Throw();
                }
            }
            catch (Exception) { }
        }
    }

    //Method to pick up ball
    void Hold()
    {
        try
        {
            ball.GetComponent<Rigidbody2D>().isKinematic = true;
            ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            ball.isStatic = true;
            //Move object to transform of object "hold" and set player to Parent
            ball.transform.position = hold.position;
            ball.transform.SetParent(transform);
            ballrb.freezeRotation = true;
            inHand = true;
        }
        catch (Exception) { }
    }

    //Method to throw ball
    public void Throw()
    {
        try
        {
            ball.GetComponent<Rigidbody2D>().isKinematic = false;
            ball.transform.SetParent(null);
            
            ballrb.AddForce(Vector2.ClampMagnitude((throwPos), maxMouseRadius) * (throwForce - (mouseRadius*2.5f)));
            ballrb.freezeRotation = false;
            inHand = false;
        }
        catch (Exception) { }
    }
}


