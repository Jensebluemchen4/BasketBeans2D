using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 2.5f, -10f);
    private Vector3 velocity = Vector3.zero;
    private Vector3 toFollowPos;
    private float smoothness = 0.2f;
    [SerializeField] private Transform toFollow;


    private void LateUpdate()
    {
        toFollowPos = toFollow.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, toFollowPos, ref velocity, smoothness);
    }


}