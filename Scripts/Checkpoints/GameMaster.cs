using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
	
	//create empty en geef m dit script

	private static GameMaster instance;
	public Vector2 lastCheckPointPos;

	void Awake()
	{
		 if(instance == null)
		 {
		 	 instance = this;
			 DontDestroyOnLoad(instance);
		 } else {
		 	 Destroy(gameObject);
		 }
	}














}
