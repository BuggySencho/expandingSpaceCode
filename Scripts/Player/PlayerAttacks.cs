using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttacks : MonoBehaviour {
	// create empty and call it AttackPos, bit in front of character.
	// put it in attackPos in inspector and make it a child of character.
	// in whatIsEnemies select enemy.
	// give enemy an enemy layer first.
	// health = 10
	// Attack range 1.2
	// damage = 5
	// enemyBehaviourScript sleep de enemydamage daar in.
	// timeBtwAttack is attack cooldown, moet je zelf bepalen, ik zou zeggen tussen 0.5 en 1 sec in
	
	GameObject Enemy; 
	public EnemyDamage enemyBehaviourScript;

	private float timeBtwAttack;
	public float startTimeBtwAttack;
	
	public int health;
	public Transform attackPos;
	public LayerMask whatIsEnemies;
	public float attackRange;
	public int damage;

	void start()
	{
		Enemy = GameObject.Find("Enemy");
        enemyBehaviourScript = Enemy.GetComponent<EnemyDamage>();
	}

	void Update () 
	{
		if(timeBtwAttack <= 0)
		{
			if(Input.GetKey(KeyCode.Space))
			{
				Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
				for(int i = 0; i < enemiesToDamage.Length; i++) 
				{
					enemiesToDamage[i].GetComponent<EnemyDamage>().TakeDamage(damage);
				}
			}
		timeBtwAttack = startTimeBtwAttack;
		} else {
			timeBtwAttack -= Time.deltaTime; 
		}
	}	
	public void OnDrawGizmosSelected()
		{	
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(attackPos.position, attackRange);
		}
}
