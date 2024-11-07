using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstuckScript : MonoBehaviour
{
    private TimerTurn timerTurn;

    private void Start()
    {
        timerTurn = GameObject.Find("PlayerEnemyTurn").GetComponent<TimerTurn>();
    }
    public void UnstuckGame()
    {
        timerTurn.timer++;
    }
}
