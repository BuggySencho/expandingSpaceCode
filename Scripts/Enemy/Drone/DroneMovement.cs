using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour 
{

	//zet op drone

	public float speed;
	GameObject player; 
	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(player.transform.position.x > transform.position.x)
		{
		transform.position +=  Vector3.right * speed * Time.deltaTime;
		}
		if(player.transform.position.x < transform.position.x)
		{
		transform.position +=  Vector3.left * speed * Time.deltaTime;
		}
		if(player.transform.position.y > transform.position.y)
		{
		transform.position +=  Vector3.up * speed * Time.deltaTime;
		}
	}
}
