using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private float dayCycleSeconds;
    [SerializeField] private float currentTime = 0f;
    [SerializeField] float currentProgress;
    private float angle = 360f;
    
    private Light light;
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        currentProgress = currentTime / dayCycleSeconds;
        currentTime += Time.deltaTime;
        currentTime = currentTime % dayCycleSeconds;

        float currentRotation = Mathf.Lerp(0, 360, currentProgress);

        Vector3 angleVector = new Vector3(currentRotation, 0, 0);
        transform.rotation = Quaternion.Euler(angleVector);

    }
}

