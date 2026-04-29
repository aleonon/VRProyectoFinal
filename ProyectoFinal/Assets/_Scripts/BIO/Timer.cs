using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;

    public float currentTime = 30f;
    private bool active = true;

    private void Update()
    {
        if (!active)
        {
            return;
        }

        currentTime -= Time.deltaTime;

        UpdateTimerUI();

        if(currentTime <= 0)
        {
            PararTimer();
        }
    }

    public void PararTimer()
    {
        active = false;
        currentTime = 0f;
        UpdateTimerUI();
    }

    public void UpdateTimerUI()
    {
        if(currentTime > 0 && currentTime < 6)
        {
            timerText.color = Color.yellow;
        } else if (currentTime < 1)
        {
            timerText.color = Color.red;
        }

        
        timerText.text = currentTime.ToString("0.00");
    }
}
