using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    [SerializeField] private Vector2 screenPosition;
    
    private Camera camera;
    void Start()
    {
        camera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScreenPosition();
    }


    void UpdateScreenPosition()
    {
        screenPosition = camera.WorldToScreenPoint(transform.position);

        screenPosition.x /= Screen.width;
        screenPosition.y /= Screen.height;

        bool warp = false;
        if (screenPosition.x < 0f)
        {
            screenPosition.x += 1f;
            warp = true;
        }
        else if (screenPosition.x > 1f)
        {
            screenPosition.x -= 1f;
            warp = true;
        }

        if (screenPosition.y < 0f)
        {
            screenPosition.y += 1;
            warp = true;
        }
        else if (screenPosition.y > 1f)
        {
            screenPosition.y -= 1f;
            warp = true;
        }

        if (warp)
        {
            Debug.Log($"Player: {name} reached edge of screen {screenPosition}");
            DoWarp();
        }
    }

    void DoWarp()
    {
        Vector3 newPosition = camera.ScreenToWorldPoint(new Vector3(screenPosition.x * Screen.width,
            screenPosition.y * Screen.height, transform.position.z));

        GetComponent<Movement>().Warp(newPosition);
    }
}
