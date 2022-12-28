using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDemo : MonoBehaviour
{
    // Start is called before the first frame update
    public int StartingHealth;
    private int _health;

    [SerializeField]
    float _animSpeed = 50;

    void Start()
    {
        _health = StartingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //animate moving across the screen;
        transform.position += Vector3.right * _animSpeed * Time.deltaTime;
    }
}
