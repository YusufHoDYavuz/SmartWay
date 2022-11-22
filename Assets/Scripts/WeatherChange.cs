using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WeatherChange : MonoBehaviour
{
    void Start()
    {
        transform.DORotate(new Vector3(270, -30, 0), 240).SetLoops(-1, LoopType.Yoyo);
    }

    void Update()
    {
        
    }
}
