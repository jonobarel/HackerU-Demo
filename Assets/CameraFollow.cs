using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    private float rotationSpeed = 1f;
    void Start()
    {
        if (target == null)
        {
            Debug.Log("No target set for camera");
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDirection = target.position - transform.position;

    }
}
