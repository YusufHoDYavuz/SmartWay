using UnityEngine;

public class EndlessRoad : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        transform.position += new Vector3(0, 0, 120);
    }
}
