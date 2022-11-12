using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    [SerializeField] private Text count;
    [SerializeField] private int clockActiveDelay;
    [SerializeField] private GameObject AddedTimePanel;

    private int secondCounter;

    void Start()
    {
        StartCoroutine(SecondCounter(0));
    }

    IEnumerator SecondCounter(int startTime)
    {
        secondCounter = startTime;

        while (secondCounter > -1)
        {
            count.text = secondCounter.ToString();
            yield return new WaitForSeconds(1);
            secondCounter++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Clock"))
        {
            secondCounter += 5;
            StartCoroutine(DeactiveAndActiveClock(clockActiveDelay, other.gameObject));
        }
    }

    IEnumerator DeactiveAndActiveClock(int activeDelay, GameObject gameObject)
    {
        gameObject.transform.DOScale(Vector3.zero, 0.5f);
        gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f).OnComplete(()=> {
            gameObject.SetActive(false);
        });
        AddedTimePanel.transform.DOMoveY(1920, 0.75f).SetEase(Ease.InOutBack);
        yield return new WaitForSeconds(2);
        AddedTimePanel.transform.DOMoveY(2160, 0.5f).SetEase(Ease.InOutBack);
        yield return new WaitForSeconds(activeDelay);
        gameObject.SetActive(true);
        gameObject.transform.DOScale(new Vector3(0.2f, 0.2f, 0.2f), 0.5f);
    }

}
