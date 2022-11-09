using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("çarpışma gerçekleşti");
    }
}
