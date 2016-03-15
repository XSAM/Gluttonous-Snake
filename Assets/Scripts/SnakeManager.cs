using UnityEngine;
using System.Collections;

public class SnakeManager : MonoBehaviour 
{
    private Snake linkTop;
	
    void Awake()
    {
        linkTop = new Snake(null);
    }
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
