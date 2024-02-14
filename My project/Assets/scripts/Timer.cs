using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    int timemin = 14, timesec = 60;
    string timeTypemin, timeTypesec;

    void Start()
    {
        StartCoroutine(timer());
    }

    // Update is called once per frame
    void Update()
    {
        timeTypesec = timesec.ToString();

        timeTypemin = timemin.ToString();

        timeText.text = timeTypemin + ":" + timeTypesec;

        if (timesec <= 0)
        {
            timesec = 59;
            timemin -= 1;
        }
        
    }

    private IEnumerator timer()
    {
        WaitForSeconds waitsec = new WaitForSeconds(1.0f);

        while (timesec >= 0)
        {
            yield return waitsec;
            timesec -= 1;
        }
    }

}
