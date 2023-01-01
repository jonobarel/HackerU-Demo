using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    public float duration;

    private float _startTime;
    private float _endTime;
    private float _currentTime;
    private float _runningDuration;

    private bool isRunning = false;
    
    public void StartTimer()
    {
        if (duration <= 0)
        {
            _runningDuration = 999999;
        }
        else
        {
            _runningDuration = duration;    
        }
            
        
        _startTime = Time.time;
        _endTime = _startTime + _runningDuration;
        _currentTime = 0f;
        isRunning = true;
    }

    void Start()
    {
        StartTimer();
    }
    void Update()
    {
        if (isRunning)
        {
            _currentTime += Time.deltaTime;

            if (_startTime + _currentTime >= _endTime)
            {
                Debug.Log($"Timer {name} finished!");
                isRunning = false;
            }
        }
    }

    public float GetCurrentTime()
    {
        
        
        
        return _currentTime;
    }

    public float GetTimeRemaining()
    {
        return _runningDuration - _currentTime;
    }
}
