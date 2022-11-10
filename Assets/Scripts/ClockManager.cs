using UnityEngine;
using DG.Tweening;

public class ClockManager : MonoBehaviour
{
    [SerializeField] private GameObject minuteHand;
    [SerializeField] private GameObject hourHand;
    [SerializeField] private float minuteHandSpeed;
    [SerializeField] private float hourHandSpeed;

    void Start()
    {
        transform.DORotate(new Vector3(0, 200, 0), 3).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo); 
    }

    void Update()
    {
        minuteHand.transform.Rotate(0, 0, 50 * Time.deltaTime * minuteHandSpeed);
        hourHand.transform.Rotate(0, 0, 50 * Time.deltaTime * hourHandSpeed);
    }
}
