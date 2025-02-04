using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float speed = 10f;
    private float fasterSpeed = 13f;
    public float lifeTime = 3f;
    public int damage = 10;

    private Vector2 moveDirection;
    private TopDownMovement shooter; // Reference to the shooter script

    public void SetDirection(Vector2 direction)
    {
        moveDirection = direction.normalized;
        Destroy(gameObject, lifeTime);
    }

    public void SetShooter(TopDownMovement shooterScript)
    {
        shooter = shooterScript;
        if(shooter.isOrange == true && damage == 10)
        {
            damage = 15;
        }
    }

    void Update()
    {
        if (shooter.isWhite)
        {
            transform.Translate(moveDirection * fasterSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(moveDirection * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (shooter != null)
        {
            shooter.ResetShooting(); // Reset shooting state when the bullet is destroyed
        }
    }
}
