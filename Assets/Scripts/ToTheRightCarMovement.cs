using UnityEngine;
using DG.Tweening;

public class ToTheRightCarMovement : MonoBehaviour
{
    [SerializeField] private float carSpeed;
    void Start()
    {
        transform.DOLocalMoveX(10, carSpeed).SetEase(Ease.OutSine).SetLoops(-1);
    }
}
