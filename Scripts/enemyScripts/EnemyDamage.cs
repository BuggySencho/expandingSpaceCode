using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// zeekomkommers 2 health
// grotere enemies 5 health
public class EnemyDamage : MonoBehaviour
{

    public int health;
    public float speed;
    private float dazedTime;
    public float startDazedTime;

    void Start()
    {

    }

    void Update()
    {
        Flinch();

        if (health <= 0)
        {
            Destroy(gameObject);
        }

      //  transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Damage Taken");
    }
    public void Flinch()
    {
        if (dazedTime <= 0)
        {
            speed = 5;
        }
        else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }
    }
}
