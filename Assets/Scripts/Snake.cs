using UnityEngine;
using System.Collections;

public class Snake:MonoBehaviour
{
    protected new Rigidbody rigidbody;

    protected Vector3 velocity;
    protected Quaternion turn;
    
    public Snake lastSnakeMember;

    //链表的连接，这是一个倒写的链表，链表头是蛇尾，链表尾是蛇头，每次从链表头插入
    public virtual void Init(Snake lastSnakeMember)
    {
        this.lastSnakeMember=lastSnakeMember;
    }

    public Snake GetLastSnakeMember()
    {
        return this.lastSnakeMember;
    }

    public void SetLastSnakeMember(Snake lastSnakeMember)
    {
        this.lastSnakeMember = lastSnakeMember;
    }
    
	
	// Use this for initialization
    protected virtual void Start() 
	{
        rigidbody = GetComponent<Rigidbody>();
        turn = transform.rotation;
        velocity = new Vector3(0f, 0f, 0f);
	}
	
    protected void Moving(Vector3 movement)
    {
        rigidbody.velocity = movement.magnitude*transform.up;
    }

    protected virtual void Turning(Quaternion turn)
    {
        rigidbody.rotation=turn;
    }

    public Quaternion GetTurn()
    {
        return this.turn;
    }
}
