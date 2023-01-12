using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class dayNight : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float secondsPerDay = 24f;
    [SerializeField] private float progressSeconds=0f;
    [SerializeField] private float progressPercent;
    
    
    [SerializeField] private Color _day;

    [SerializeField] private Color _night;

    [SerializeField]
    private float angles = 360f;

    private Quaternion _currentRotation;

    private Color _currentColor;

    private float _currentIntensity;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        progressSeconds += Time.deltaTime;
        progressSeconds = progressSeconds % secondsPerDay;
        progressPercent = progressSeconds / secondsPerDay;

        Light light = GetComponent<Light>();
        light.intensity = Mathf.Lerp(0, 1, progressPercent);

        Vector3 eulerVector = new Vector3(180+Mathf.Lerp(0f, 360f, progressPercent), 0f, 0f);
        angles = eulerVector.x;
        
        transform.rotation = Quaternion.Euler(eulerVector);
        


    }
    
    

}
