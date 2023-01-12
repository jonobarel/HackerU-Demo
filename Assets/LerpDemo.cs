using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpDemo : MonoBehaviour
{

    [SerializeField] 
    private Transform StartingPoint;

    [SerializeField] private Transform Target;

    [SerializeField] private float seconds;
    private float elapsed;
    void Start()
    {
        transform.position = StartingPoint.position;
        elapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;

        float currentProgress = elapsed / seconds;
        if (currentProgress >= 1)
        {
            Transform temp = Target;
            Target = StartingPoint;
            StartingPoint = temp;
            elapsed = 0;
        }

        transform.position = Vector3.Lerp(StartingPoint.position, Target.position, elapsed / seconds);


    }
}
