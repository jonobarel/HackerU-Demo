using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpStrengthAdjuster : MonoBehaviour
{
    private float scrollbarPosition;
    
    [SerializeField]
    private float forceMultiplier;

    private PlayerMovement player;

    void Awake()
    {
        player = GetComponent<PlayerMovement>();
    }
    

    public void ValueChanged(float newValue)
    {
        Debug.Log($"Scrollbar new value: {newValue}");
        player.ChangeJumpPower(newValue*forceMultiplier);
    }
    
}
