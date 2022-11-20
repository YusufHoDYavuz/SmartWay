using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    [SerializeField] private Text timeCounter;
    [SerializeField] private float timeValue;
    [SerializeField] private int clockActiveDelay;
    [SerializeField] private GameObject AddedTimePanel;

    private int secondCounter;
    private int minuteCounter;

    void Start()
    {
    }

    private void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }

        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);

        timeCounter.text = string.Format("{0:00}:{1:00}", minutes, seconds);
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
