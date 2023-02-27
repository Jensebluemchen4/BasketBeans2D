using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private Transform hold;
    public GameObject ball;
    [SerializeField] private Rigidbody2D ballrb;
    [SerializeField] private float throwForce = 25f;
    [SerializeField] private float maxMouseRadius = 10f;
    [SerializeField] private float maxAutoPickUpDist = 20f;
    [SerializeField] private float playerDistanceToObject;
    public float mouseRadius;


    private Rigidbody2D player;
    public bool inHand = true;
    public bool isTeleporting = false;
    public Player pm;
    private Vector2 throwPos;


    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        if (inHand)
        Hold();
        ball.transform.position = hold.position;
    }

    void Update()
    {
        if (isTeleporting == true)
        {
            Teleport();
        }

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
                if (inHand == false && playerDistanceToObject > maxAutoPickUpDist && isTeleporting == false)
                {
                    isTeleporting = true;
                }
                else if (Input.GetKeyDown(KeyCode.Mouse1) && inHand == false && isTeleporting == false)
                {
                    isTeleporting = true;
                }
                else if (Input.GetKeyDown(KeyCode.Mouse0) && isTeleporting == false && inHand == true)
                {
                    ball.GetComponent<Collider2D>().enabled = true;
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
            ball.transform.SetParent(transform);
            inHand = true;
            ballrb.freezeRotation = true;
            inHand = true;
            ball.GetComponent<Rigidbody2D>().isKinematic = true;
            ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            ball.isStatic = true;
            //Move object to transform of object "hold" and set player to Parent
            //ball.transform.position = hold.position;

            //if (ball.transform.position != hold.position)
            //Teleport();
        }
        catch (Exception) { }
    }

    void Teleport()
    {
        if(Vector3.Distance(ball.transform.position, hold.position) < 0.1f)
        {
            isTeleporting = false;
            Hold();
        }
        ball.GetComponent<Collider2D>().enabled = false;
        ball.transform.position = Vector3.MoveTowards(ball.transform.position, hold.position, 30 * Time.deltaTime);
    }

    //Method to throw ball
    public void Throw()
    {
        try
        {
            ball.GetComponent<Rigidbody2D>().isKinematic = false;
            ball.transform.SetParent(null);
            
            ballrb.AddForce(Vector2.ClampMagnitude((throwPos + player.velocity / 4.5f), maxMouseRadius) * (throwForce - (mouseRadius*2.5f)));
            ballrb.freezeRotation = false;
            inHand = false;
        }
        catch (Exception) { }
    }
}


