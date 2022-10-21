using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    Vector3 test;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition,ref test ,smoothSpeed, 5);
        transform.position = smoothedPosition;

        transform.LookAt(player);
    }
}
