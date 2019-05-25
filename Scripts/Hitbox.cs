using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            col.GetComponent<EnemyDamage>().health -= 50;
        }

        if (col.CompareTag("Majora's Mask"))
        {
            col.GetComponent<MaskBoss>().health -= 50;
        }
    }
}
