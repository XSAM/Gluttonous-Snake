using UnityEngine;
using System.Collections;

public class SnakeManager : MonoBehaviour 
{
    public GameObject snakeHead;
    public GameObject snakeBody;
    public float distance = -1.2f;
    public bool addSnakeBody = false;

    private Snake linkTop;
    private GameObject instanceTemp;
    private Snake snakeTemp;


    private Vector3 position;
    private Snake lastSnakeMember;
	
    void Awake()
    {
        instanceTemp=Instantiate(snakeHead,new Vector3(0,0.58f,0),Quaternion.Euler(90,0,0)) as GameObject;
        snakeTemp=instanceTemp.GetComponent<Snake>();

        linkTop=new Snake();
        linkTop.Init(snakeTemp);
        for (int i = 0; i < 6; ++i)
            AddSnakeBody();
    }
	// Use this for initialization
	void Start () 
	{

	}

    void AddSnakeBody()
    {
        lastSnakeMember=linkTop.GetLastSnakeMember();
        position = lastSnakeMember.transform.up * -1.2f + lastSnakeMember.transform.position;
        //Debug.Log(lastSnakeMember.transform.up);
        instanceTemp = Instantiate(snakeBody, position, Quaternion.Euler(90,lastSnakeMember.transform.rotation.eulerAngles.y, 0)) as GameObject;
        snakeTemp = instanceTemp.GetComponent<Snake>();
        snakeTemp.Init(linkTop.GetLastSnakeMember());

        linkTop.SetLastSnakeMember(snakeTemp);
    }
	
	// Update is called once per frame
	void Update () 
	{
		if(addSnakeBody)
        {
            AddSnakeBody();
            addSnakeBody = false;
        }
	}
}
