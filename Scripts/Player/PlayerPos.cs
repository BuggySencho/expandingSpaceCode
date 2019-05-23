using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour {

	//gooi op player
	
	private GameMaster gm;
	// Use this for initialization
	void Start() 
	{
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		transform.position = gm.lastCheckPointPos;
		Debug.Log("hewwo");
	}
	
	// Update is called once per frame
	void Update() 
	{
		if(Input.GetKeyDown(KeyCode.E))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
