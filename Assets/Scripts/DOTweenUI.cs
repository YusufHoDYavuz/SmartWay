using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOTweenUI : MonoBehaviour
{
    [SerializeField] private GameObject tapToStartPanel;
    [SerializeField] private GameObject restartGamePanel;
    [SerializeField] private GameObject pathCreator;
    [SerializeField] private GameObject timeCounter;
    [SerializeField] private float tapToStartSpeed;

    void Start()
    {
        tapToStartPanel.transform.DOScale(new Vector3(0.9f, 0.9f, 0.9f), tapToStartSpeed).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        restartGamePanel.transform.DOScale(new Vector3(0.9f, 0.9f, 0.9f), tapToStartSpeed).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    // CALLED BY BUTTON
    public void StartGame()
    {
        tapToStartPanel.SetActive(false);
        pathCreator.SetActive(true);
        timeCounter.SetActive(true);
    }
}
