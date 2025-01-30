using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 3f;

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
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
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
