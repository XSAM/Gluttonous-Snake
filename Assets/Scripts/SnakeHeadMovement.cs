using UnityEngine;
using System.Collections;

public class SnakeHeadMovement : MonoBehaviour 
{
    public float speed;
    public float turnSpeed;

    private new Rigidbody rigidbody;
    private float horizontal;
    private float vertical;
	
	// Use this for initialization
	void Start () 
	{
        rigidbody = GetComponent<Rigidbody>();

	}

    void FixedUpdate()
    {
        Vector3 movement = transform.up * vertical * speed;//*Time.deltaTime;
        Debug.Log("movement:"+movement);
        //rigidbody.MovePosition(movement+rigidbody.position);
        rigidbody.velocity = movement * Time.deltaTime;
        rigidbody.MoveRotation((Quaternion.Euler(new Vector3(0, horizontal * turnSpeed, 0) * Time.deltaTime) * rigidbody.rotation));
    }
	
	// Update is called once per frame
	void Update () 
	{
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
	}
}
