using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 2.2f, -10f);
    private Vector3 velocity = Vector3.zero;
    private Vector3 toFollowPos;
    private float smoothness = 0.08f;
    [SerializeField] private Transform toFollow;
    [SerializeField] private float lockPos;
    [SerializeField] private bool lockX = false;
    [SerializeField] private bool lockY = false;

    private void LateUpdate()
    {
        toFollowPos = toFollow.position + offset;

        if (lockX == false && lockY == false || lockX == true && lockY == true)
            transform.position = Vector3.SmoothDamp(transform.position, toFollowPos, ref velocity, smoothness);
        else if (lockX == true && lockY == false)
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(lockPos, toFollowPos.y, -10f), ref velocity, smoothness);
        else if (lockX == false && lockY == true)
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(toFollowPos.x, lockPos, -10f), ref velocity, smoothness);
    }
}