using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SnakeBody : Snake 
{
    private float lastTime;
    private bool isCoroutine;
    private bool startTurn;
    private List<Quaternion> lastTurn;

    public float delayTime = 0.2f;

    protected override void Start()
    {
        isCoroutine = false;
        lastTurn = new List<Quaternion>();
        base.Start();
    }

    void FixedUpdate()
    {
        Moving(SnakeHead.lastestVelocity);

        if(!isCoroutine)
        {
            lastTime = Time.time;
            isCoroutine = true;
        }
        if(lastTime+delayTime<=Time.time)
        {
            startTurn = true;
        }
        lastTurn.Add(lastSnakeMember.GetTurn());
        if(startTurn)
        {
            turn = lastTurn[0];
            lastTurn.RemoveAt(0);
        }

        if(turn!=Quaternion.identity)
        {
            Turning(turn);
        }
    }
}
