using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPickUp : MonoBehaviour 
{

	// op t zwaard zetten die je moet oppakken

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			Pickup(other);
		}
	}

	public void Pickup(Collider2D player)
	{
		Debug.Log("Sword Activated!");
		PlayerAttacks damage = player.GetComponent<PlayerAttacks>();
		damage.damage = 10;
		Destroy(gameObject);
	}



}
