using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    PlayerMovement player;

    TextMeshProUGUI tmpText;

    void Start()
    {
        tmpText = GetComponent<TextMeshProUGUI>();
        tmpText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
