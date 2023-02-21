using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce;
    private float moveSpeed;
    public float sprint;
    public float walk;
    private float moveInput;
    private Rigidbody2D rb;

    private bool onGround;
    public LayerMask isGround;
    public Transform groundCheck;
    public float radiusCheck;
    

    public Vector3 mousePosition;
    bool lookLeft;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Time.timeScale == 1)
        {
            FollowMouse();
            if (onGround == true && Input.GetButtonDown("Jump"))
                rb.velocity = Vector2.up * jumpForce;
            if (lookLeft == true && mousePosition.x > 0)
                Flip();
            else if (lookLeft == false && mousePosition.x < 0)
                Flip();
        }
    }

    void FixedUpdate()
    {

        onGround = Physics2D.OverlapCircle(groundCheck.position, radiusCheck, isGround);
        moveInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift))
            moveSpeed = sprint;
        else
            moveSpeed = walk;

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    public void FollowMouse()
    {
        mousePosition = Input.mousePosition;
        mousePosition = (Camera.main.ScreenToWorldPoint(mousePosition) - transform.position);
    }

    void Flip()
    {
        lookLeft = !lookLeft;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
