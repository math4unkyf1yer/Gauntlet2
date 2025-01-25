using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject player;
    public float speed;
    public int health;

    private void Start()
    {
        player = GameObject.Find("Player");

    }
    private void Update()
    {
        if (player != null)
        {
            // Move the enemy towards the player's position
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
        if(health <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            health -= 5;
            Health healthScript = collision.gameObject.GetComponent<Health>();
            healthScript.TookDamage(5);
        }
        if(collision.gameObject.tag == "Bullet")
        {
            health -= 10;
        }
    }
}
