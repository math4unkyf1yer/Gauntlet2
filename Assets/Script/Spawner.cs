using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public int enemyAmount;
    public Transform spawnPlace;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnEnemy",1,3);
    }

    private void spawnEnemy()
    {
        if(enemyAmount <= 9)
        {
            enemyAmount++;
            GameObject enemyclones = Instantiate(enemy, spawnPlace);
            EnemyMovement enemyScript = enemyclones.GetComponent<EnemyMovement>();
            enemyScript.whichSpawner = gameObject;
            enemyclones.transform.position = spawnPlace.position;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Dead();
        }
    }
    public void Dead()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 10;
        }
    }

}
