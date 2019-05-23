using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour 
{

	// health = 10
	// num of hearts = 10
	// heart size is 10 en dan in elke gooi je een fullHeart Image
	//full heart en empty heart spreken voor zich
	// op player


	public int health;
	public int numOfHearts;

	public Image[] hearts;
	public Sprite fullHeart;
	public Sprite emptyHeart;

	void Start()
	{

	}

	void Update()
	{
		
		if(health <= 0)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

		if(health > numOfHearts)
		{
			health = numOfHearts;	
		}

		for(int i = 0; i <hearts.Length; i++)
		{
			if(i < health)
			{
				hearts[i].sprite = fullHeart;
			} else {
				hearts[i].sprite = emptyHeart;
			}

			if(i < numOfHearts)
			{
				hearts[i].enabled = true;
			} else {
				hearts[i].enabled = false;
			}
		}
	}
	public void TakeDamage(int damage)
	{
		health -= damage;
		Debug.Log("get yeeted");
	}
}
