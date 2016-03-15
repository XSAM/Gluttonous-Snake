using UnityEngine;
using System.Collections;

public class SnakeHeadMovement : MonoBehaviour
{
    public float speed=300f;
    public float turnSpeed=180f;

    private new Rigidbody rigidbody;
    private float horizontal;
    //private float vertical;

    [HideInInspector]
    public Vector3 lastVelocity;
    [HideInInspector]
    public Quaternion lastTurn;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Record()
    {
        lastVelocity = rigidbody.velocity;
        lastTurn = rigidbody.rotation;
    }

    void FixedUpdate()
    {
        Vector3 movement = transform.up * speed;//*Time.deltaTime;
        //Debug.Log("movement:"+movement);
        //rigidbody.MovePosition(movement+rigidbody.position);
        rigidbody.velocity = movement * Time.deltaTime;
        rigidbody.MoveRotation((Quaternion.Euler(new Vector3(0, horizontal * turnSpeed, 0) * Time.deltaTime) * rigidbody.rotation));
        Record();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        //vertical = Input.GetAxis("Vertical");
    }
}
