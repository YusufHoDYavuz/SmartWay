using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothSpeed;
    Vector3 offset;
    Vector3 currentVelocity = Vector3.zero;

    void Awake()
    {
        offset = transform.position - target.position;
    }

    void Update()
    {
        Vector3 targetPos = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref currentVelocity, smoothSpeed);
    }
}
