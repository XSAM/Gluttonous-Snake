using UnityEngine;
using System.Collections;

public class SnakeHead : Snake
{
    public float speed=300f;
    public float turnSpeed = 180f;
    static public Vector3 lastestVelocity;

    private float horizontal;
	
    void FixedUpdate()
    {
        velocity = transform.up * speed * Time.deltaTime;
        lastestVelocity = velocity;
        turn = Quaternion.Euler(new Vector3(0, horizontal * turnSpeed, 0) * Time.deltaTime)*rigidbody.rotation;

        Moving(velocity);
        Turning(turn);
        //Debug.Log("turn:" + turn);
    }

	// Update is called once per frame
	void Update () 
	{
        horizontal = Input.GetAxis("Horizontal");
	}
}
