using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotWalk : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float left = 0f;
    [SerializeField] private float right = 0f;
    bool lookRight = true;
    float robotStartPosition;

    private void Awake()
    {
        robotStartPosition = transform.position.x;
    }

    void Update()
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

    public void Flip()
    {
        lookRight = !lookRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
