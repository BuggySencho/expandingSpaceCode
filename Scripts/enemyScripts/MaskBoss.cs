using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaskBoss : MonoBehaviour
{
    public GameObject Player;
    public int chance;
    public float tinyTimer;
    public GameObject spike;
    GameObject spikePrefab;
    public GameObject laser;
    GameObject laserPrefab;
    public bool attackRange = false;
    public float destroyTimer;
    public int health = 750;

    // Start is called before the first frame update
    void Start()
    {
       Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("victoryScreen");

        }

        if (attackRange)
        {
            tinyTimer += Time.deltaTime;
        }

        if (tinyTimer >= 4)
        {
            chance = Random.Range(0, 100);
            tinyTimer = 0;
            SpikeAttack();
            LaserAttack();
        }
    }

    void SpikeAttack()
    {
        if (chance >=0 && chance <= 40)
        {
            spikePrefab = Instantiate(spike, new Vector3(Player.transform.position.x, -36, -1), spike.transform.rotation) as GameObject;
        }
    }

    void LaserAttack()
    {
        if (chance >= 41 && chance <= 81)
        {
            laserPrefab = Instantiate(laser, new Vector3(76, -37, -1), laser.transform.rotation) as GameObject;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            attackRange = true;
        }
    }
}
