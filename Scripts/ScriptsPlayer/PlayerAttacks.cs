using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttacks : MonoBehaviour
{
    // create empty and call it AttackPos, bit in front of character.
    // put it in attackPos in character and make it a child of character.
    // in whatIsEnemies select enemy.
    // give enemy an enemy layer first.

    public GameObject Enemy;
    public EnemyDamage enemyBehaviourScript;

    public float timeBtwAttack;
    public float startTimeBtwAttack;

    public int health;
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;
    public Animator animator;

    void start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyBehaviourScript = Enemy.GetComponent<EnemyDamage>();
    }

    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("hewwo");
                animator.SetBool("IsAttacking", true);
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    Debug.Log("hewwo");
                    enemiesToDamage[i].GetComponent<EnemyDamage>().TakeDamage(damage);
                }
                animator.SetBool("IsAttacking", false);
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
