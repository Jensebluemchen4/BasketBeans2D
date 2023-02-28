using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float jumpForce = 11;
    private float moveSpeed;
    public float sprint;
    public float walk;
    private float moveInput;

    public LayerMask isGround;
    public Transform groundCheck;
    private bool onGround;
    public float radiusCheck;
    private bool isJumping;

    private float jumpTime = 0.19f;
    private float jumpCounter;

    private float bufferTime = 0.1f;
    private float bufferCounter;

    private float coyoteTime = 0.04f;
    private float coyoteTimeCounter;

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
            if (lookLeft == true && mousePosition.x > 0)
                Flip();
            else if (lookLeft == false && mousePosition.x < 0)
                Flip();


            if (Input.GetButtonDown("Jump"))
            {
                bufferCounter = bufferTime;
            }
            else
            {
                bufferCounter -= Time.deltaTime;
            }

            if (onGround == true)
            {
                coyoteTimeCounter = coyoteTime;
            }
            else
            {
                coyoteTimeCounter -= Time.deltaTime;
            }

            if (bufferCounter > 0 && coyoteTimeCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                isJumping = true;
                bufferCounter = 0;
                jumpCounter = jumpTime;
            }

            if (Input.GetButton("Jump") && isJumping == true)
            {
                if (jumpCounter > 0)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    jumpCounter -= Time.deltaTime;
                }
                else
                {
                    isJumping = false;
                }
            }
            if (Input.GetButtonUp("Jump"))
            {
                isJumping = false;
                coyoteTimeCounter = 0;
            }

        }
    }

    void FixedUpdate()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, radiusCheck, isGround);
       
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (Input.GetKey(KeyCode.LeftShift))
            moveSpeed = sprint;
        else
            moveSpeed = walk;
    }

    public void FollowMouse()
    {
        mousePosition = Input.mousePosition;
        mousePosition = (Camera.main.ScreenToWorldPoint(mousePosition) - transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Spikes"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.GetComponent<Robot>().alive == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }


    void Flip()
    {
        lookLeft = !lookLeft;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
