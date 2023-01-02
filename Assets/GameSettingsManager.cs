using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingsManager : MonoBehaviour
{
    
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);    
    }

    
}
