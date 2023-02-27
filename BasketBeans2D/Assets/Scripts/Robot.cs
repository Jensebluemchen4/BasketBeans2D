using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float left = 0f;
    [SerializeField] private float right = 0f;
    private Rigidbody2D rob;
    private PickUp playerHand;
    public bool alive = true;
    bool lookRight = true;
    float robotStartPosition;
    [SerializeField] private bool indestructable = false;

    private void Awake()
    {
        rob = GetComponent<Rigidbody2D>();
        playerHand = GameObject.Find("Player").GetComponent<PickUp>();
        robotStartPosition = transform.position.x;
    }

    void Update()
    {
        if (alive)
        {
            if (lookRight == true)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                if (transform.position.x > robotStartPosition + right)
                    Flip();
            }

            if (lookRight == false)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
                if (transform.position.x < robotStartPosition - left)
                    Flip();
            }
        }
        else
        {
            StartCoroutine(DestroyAfterTime());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (indestructable == false)
        {
            if ((collision.gameObject.CompareTag("Objects") && playerHand.inHand == false) || collision.gameObject.CompareTag("Enemy"))
            {
                rob.freezeRotation = false;
                rob.gravityScale = 1.5f;
                alive = false;
            }
        }
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    public void Flip()
    {
        lookRight = !lookRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
