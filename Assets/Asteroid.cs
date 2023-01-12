using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var angles = transform.rotation.eulerAngles;
        angles.z = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(angles);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
