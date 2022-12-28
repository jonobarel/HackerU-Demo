using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomControl : MonoBehaviour
{
    public SpriteRenderer imageToZoom;
    [SerializeField] private int _zoomScale = 5;

    private Scrollbar _scrollbar;
    [SerializeField]
    private float currentScale;

    void Awake()
    {
        _scrollbar = GetComponent<Scrollbar>();
        _scrollbar.onValueChanged.AddListener(ValueChanged);
    }

    private void OnDestroy()
    {
        _scrollbar.onValueChanged.RemoveListener(ValueChanged);
    }

    public void ValueChanged(float f)
    {
        currentScale = (f*_zoomScale + 1); 
        imageToZoom.transform.localScale = new Vector3(currentScale, currentScale);
    }
}
