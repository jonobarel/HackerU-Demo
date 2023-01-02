using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CountdownTimer : MonoBehaviour
{
    public float duration;

    private float _startTime;
    private float _endTime;
    private float _currentTime;
    private float _runningDuration;

    [SerializeField] private UnityEvent onTimerElapse;

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
                if (onTimerElapse != null)
                {
                    onTimerElapse.Invoke();
                }
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
