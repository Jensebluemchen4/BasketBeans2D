using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour
{
    public Camera cam;
    public float parallax;
    private float length;
    private float startPos;
    public GameObject player;


    // Start is called before the first frame update
    void Awake()
    {
        startPos = 0;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallax));
        float distance = (cam.transform.position.x * parallax);
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if (temp > startPos + length)
        {
            startPos = startPos + length;
        }
        else if (temp < startPos - length)
        {
            startPos = startPos - length;
        }
    }
}
