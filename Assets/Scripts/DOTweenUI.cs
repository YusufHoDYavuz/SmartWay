using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOTweenUI : MonoBehaviour
{
    [SerializeField] private GameObject tapToStartPanel;
    public GameObject restartGamePanel;
    public GameObject pathCreator;
    [SerializeField] private GameObject timeCounter;
    [SerializeField] private GameObject player;
    [SerializeField] private float tapToStartSpeed;
    public Ragdoll RD;
    public TimeCounter TC;

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

    public void RestartGame()
    {
        //StartCoroutine(RestartGameDelay(3));
        RD.RagdollDeactive();
        player.transform.position = new Vector3(9.5f, -3.3f, 6.7f);
        player.transform.rotation = Quaternion.Euler(Vector3.zero);
        restartGamePanel.SetActive(false);
        TC.timeValue = 30;
        pathCreator.SetActive(true);
    }

    /* IEnumerator RestartGameDelay(float waitDelay)
    {
        yield return new WaitForSeconds(waitDelay);

    } */
}
