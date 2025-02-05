using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject player;
    public float speed;
    public int health;
    public GameObject whichSpawner;
    private Spawner spawnScript;
    public int Damage;
    private Animator animator;
    private Vector2 lastDirection;

    private void Start()
    {
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (player != null)
        {
            // Move the enemy towards the player
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // Update animation
            UpdateAnimation(direction);
        }

        if (health <= 0)
        {
            Dead();
        }
    }

    private void UpdateAnimation(Vector3 direction)
    {
        if (direction.magnitude > 0)
        {
            lastDirection = new Vector2(direction.x, direction.y);
        }

        animator.SetFloat("MoveX", lastDirection.x);
        animator.SetFloat("MoveY", lastDirection.y);
    }

    private void Dead()
    {
        spawnScript = whichSpawner.GetComponent<Spawner>();
        spawnScript.enemyAmount--;
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            health -= 5;
            Health healthScript = collision.gameObject.GetComponent<Health>();
            healthScript.TookDamage(Damage);
        }
        if (collision.gameObject.tag == "Bullet")
        {
            Shoot shootScript = collision.gameObject.GetComponent<Shoot>();
            health -= shootScript.damage;
        }
    }
}
