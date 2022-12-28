using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonImageSelector : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
{
    public Sprite baseImage;
    public Sprite mouseOverImage;
    public Sprite mouseDownImage;

    public UnityEvent ButtonDownEvent;
    private Button _buttonComponent;

    void Awake()
    {
        _buttonComponent = GetComponent<Button>();
        if (_buttonComponent == null)
        {
            throw new ArgumentNullException("Missing Button component");
        }

        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Pointer Down");
        if (ButtonDownEvent != null)
        {
            ButtonDownEvent.Invoke();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Pointer Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Pointer Exit");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Pointer Up");
    }
}
