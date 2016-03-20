using UnityEngine;
using System.Collections;

public class SnakeManager : MonoBehaviour 
{
    public GameObject snakeHead;
    public GameObject snakeBody;
    public GameObject food;
    public int snakeBodyCount=6;
    public float distance = -1.2f;
    public bool addSnakeBody = false;

    private Snake linkTop;
    private GameObject instanceTemp;
    private Snake snakeTemp;


    private Vector3 position;
    private Snake lastSnakeMember;

    private float lastSpawnFoodTime;
    private bool isSpawned;
    private Vector3 foodPosition;
    private RaycastHit hit;
	
    void Awake()
    {
        isSpawned = false;
        foodPosition = Vector3.zero;
        instanceTemp=Instantiate(snakeHead,new Vector3(0,0.58f,0),Quaternion.Euler(90,0,0)) as GameObject;
        snakeTemp=instanceTemp.GetComponent<Snake>();

        linkTop=new Snake();
        linkTop.Init(snakeTemp);
        for (int i = 0; i < snakeBodyCount; ++i)
            AddSnakeBody();
    }

    public void AddSnakeBody()
    {
        lastSnakeMember=linkTop.GetLastSnakeMember();
        position = lastSnakeMember.transform.up * -1.2f + lastSnakeMember.transform.position;
        //Debug.Log(lastSnakeMember.transform.up);
        instanceTemp = Instantiate(snakeBody, position, Quaternion.Euler(90,lastSnakeMember.transform.rotation.eulerAngles.y, 0)) as GameObject;
        snakeTemp = instanceTemp.GetComponent<Snake>();
        snakeTemp.Init(linkTop.GetLastSnakeMember());

        linkTop.SetLastSnakeMember(snakeTemp);
    }

    public bool SpawnFood()
    {
        foodPosition.Set(Random.Range(-24, 24), 0.5f, Random.Range(-24, 24));
        if(Physics.SphereCast(foodPosition,0.7f,Vector3.zero,out hit))
        {
            return false;
        }
        Instantiate(food, foodPosition, Quaternion.identity);
        return true;
    }
	
	// Update is called once per frame
	void Update () 
	{
		if(addSnakeBody)
        {
            AddSnakeBody();
            addSnakeBody = false;
        }
        if(!isSpawned)
        {
            if(SpawnFood())
            {
                isSpawned = true;
                lastSpawnFoodTime = Time.time;
            }
            //else
            //如果食物生成失败，则在下一次Update调用的时候再次尝试生成食物
        }
        if(lastSpawnFoodTime+4f<Time.time)
        {
            isSpawned = false;
        }

        if(SnakeHead.isAddSnakeBody)
        {
            AddSnakeBody();
            SnakeHead.isAddSnakeBody = false;
        }
	}
}
