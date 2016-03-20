using UnityEngine;
using System.Collections;

public class SnakeHead : Snake
{
    public float speed=300f;
    public float turnSpeed = 180f;
    static public Vector3 lastestVelocity;
    static public bool isGameOver = false;
    static public bool isAddSnakeBody = false;

    private float horizontal;
	
    void FixedUpdate()
    {
        if(!isGameOver)
        {
            velocity = transform.up * speed * Time.deltaTime;
            lastestVelocity = velocity;
            turn = Quaternion.Euler(new Vector3(0, horizontal * turnSpeed, 0) * Time.deltaTime) * rigidbody.rotation;

            Moving(velocity);
            Turning(turn);
        }
        else
        {
            rigidbody.isKinematic = true;
            rigidbody.detectCollisions = false;
        }
        //Debug.Log("turn:" + turn);
    }

	// Update is called once per frame
	void Update () 
	{
        horizontal = Input.GetAxis("Horizontal");
        if(isGameOver)
        {
            lastestVelocity = Vector3.zero;
        }
	}

    //void OnCollisionEnter(Collision collider)
    //{
    //    if (collider.gameObject.tag == "Body")
    //    {
    //        SnakeHead.isGameOver = true;
    //    }
    //}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Food")
        {
            collider.gameObject.SetActive(false);
            Destroy(collider.gameObject);
            isAddSnakeBody = true;
        }
        else
        {
            SnakeHead.isGameOver = true;
        }
    }
}
