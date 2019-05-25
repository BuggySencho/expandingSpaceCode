using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KomkommerAttack : MonoBehaviour
{

    // exact t zelfde als de drone maar dan attack 1

    GameObject Player;
    public PlayerHealth QuickHealth;

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public int health;
    public Transform attackPos;
    public LayerMask whatIsPlayer;
    public float attackRange;
    public int damage;
    public Animator animator;
    public float tinyTimer;
    public bool startTimer = false;

    /*   void Start()
       {
           Player = GameObject.Find("Player");
           QuickHealth = Player.GetComponent<QuickHealth>();
       }    */


       void Update()
       {

        if (startTimer)
        {
            tinyTimer += Time.deltaTime;
        }

        if (tinyTimer >= 0.5)
        {
            animator.SetBool("IsAttacking", false);
            tinyTimer = 0;
            startTimer = false;
        }
        /* if (timeBtwAttack <= 0)
         {

             Collider2D[] playersToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsPlayer);
             for (int i = 0; i < playersToDamage.Length; i++)
             {
                 Debug.Log("Hewwo");
                 playersToDamage[i].GetComponent<QuickHealth>().playerHealth -= 5;
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
         {
             Gizmos.color = Color.red;
             Gizmos.DrawWireSphere(attackPos.position, attackRange);
         }    */
    } 

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            startTimer = true;
            animator.SetBool("IsAttacking", true);
            col.GetComponent<QuickHealth>().playerHealth -= 3;
        }
    }
}