using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

	// op elke enemy plaatsen
	// speed = 5
	// start dazedTime is niet van toepassing nog
	// health ook zelf bepalen, moet t zelfde zijn als de andere health aangegeven op de character tho
	
	public int health;
	public float speed;
	private float dazedTime;
	public float startDazedTime;

	void Start ()
	{
		
	}
	
	void Update () 
	{
		Flinch();

		if(health <= 0)
		{
			Destroy(gameObject);
		}

	}

	public void TakeDamage(int damage)
	{
		health -= damage;
		Debug.Log("Damage Taken");
	}
	public void Flinch()
	{
		if(dazedTime <= 0)
		{
			speed = 5;
		} else {
			speed = 0;
			dazedTime -= Time.deltaTime;
		}
	}
}
