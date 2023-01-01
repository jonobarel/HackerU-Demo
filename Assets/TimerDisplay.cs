using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField]
    private CountdownTimer _countdownTimer;

    private TextMeshProUGUI timerText;
    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        timerText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        float currentTimer = _countdownTimer.GetCurrentTime();

        float minutes = currentTimer / 60f;
        float seconds = currentTimer % (60);
        
        timerText.text = $"{minutes:00}:{seconds:00}";
        
    }
}
