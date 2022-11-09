using UnityEngine;
using DG.Tweening;

public class ToTheLeftCarMovement : MonoBehaviour
{
    [SerializeField] private float carSpeed;
    void Start()
    {
        transform.DOLocalMoveX(-5, carSpeed).SetEase(Ease.OutSine).SetLoops(-1);
    }
}
