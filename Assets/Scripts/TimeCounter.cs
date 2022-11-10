using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    [SerializeField] private Text count;
    private int counter;

    void Start()
    {
        StartCoroutine(Counter(5));
    }

    void Update()
    {
    }

    IEnumerator Counter(int seconds)
    {
        counter = seconds;

        while (counter > -1)
        {
            count.text = "0: " + count.ToString();
            yield return new WaitForSeconds(1);
            counter++;
        }
    }
}
