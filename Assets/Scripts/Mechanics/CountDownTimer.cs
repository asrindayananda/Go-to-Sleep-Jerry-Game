using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CountDownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startTime = 10f;

    [SerializeField] Text CountDownTimerText;

    // Use this for initialization
    void Start()
    {
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        CountDownTimerText.text = currentTime.ToString();
    }
}
