using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SpikeScript : MonoBehaviour 
{
	// zet op de spikes
	
	void Start()
	{

	}

	void OnCollisionEnter2D(Collision2D other)
		{
			if(other.gameObject.tag == "Player")
    		{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    		}
		}


}
