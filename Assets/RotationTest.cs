using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    Quaternion _threeQuarters = Quaternion.AngleAxis(270, Vector3.up);

    private Quaternion startRotation;
    // Start is called before the first frame update
    void Start()
    {
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        float sinTime = Mathf.Sin(Time.time);
        
        
    }
}
