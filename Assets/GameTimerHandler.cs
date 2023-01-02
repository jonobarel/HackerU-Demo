using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimerHandler : MonoBehaviour
{
    [SerializeField] private int duration;
    private CountdownTimer timer;
    void Start()
    {
        timer = GetComponent<CountdownTimer>();
        timer.duration = duration;
        timer.StartTimer();
    }

    public void GoToEndScreen()
    {
        SceneManager.LoadScene("EndgameScene");
    }
}
