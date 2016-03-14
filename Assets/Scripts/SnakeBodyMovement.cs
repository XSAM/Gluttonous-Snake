using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SnakeBodyMovement : MonoBehaviour 
{
    private new Rigidbody rigidbody;
    private SnakeHeadMovement snakeHeadMovement;
    private float lastTime;
    private bool isCoroutine;
    private bool startTurn;
    public float delayTime = 0.2f;

    //private Quaternion lastTurn;
    private Quaternion turn;
    public List<Quaternion> lastTurn;

	
	// Use this for initialization
	void Start () 
	{
        rigidbody = GetComponent<Rigidbody>();
        snakeHeadMovement = GameObject.FindGameObjectWithTag("Head").GetComponent<SnakeHeadMovement>();
        turn = Quaternion.identity;
        isCoroutine = false;
        startTurn = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
        if(!isCoroutine)
        {
            lastTime = Time.time;
            isCoroutine = true;
        }
        if(lastTime+delayTime<=Time.time)
        {
            startTurn = true;
        }
        lastTurn.Add(snakeHeadMovement.lastTurn);
        if(startTurn)
        {
            turn = lastTurn[0];
            lastTurn.RemoveAt(0);
        }

		if(snakeHeadMovement.lastVelocity!=null)
        {
            rigidbody.velocity = snakeHeadMovement.lastVelocity.magnitude*transform.up;
        }
        if (turn != Quaternion.identity)
        {
            rigidbody.rotation = turn;
        }

	}
}
