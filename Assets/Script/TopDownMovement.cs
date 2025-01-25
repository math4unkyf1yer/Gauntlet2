using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    [Header("Shooting Settings")]
    public GameObject projectilePrefab;
    public Transform shootPoint; // Point from where the projectile spawns
    public float fireRate = 0.5f; // Time between shots

    private Vector2 moveInput;
    private float nextFireTime = 0f;

    void Update()
    {
        // Movement input
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        if (moveInput.sqrMagnitude > 1)
            moveInput = moveInput.normalized;

        // Shooting input
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void FixedUpdate()
    {
        // Move the player
        transform.Translate(moveInput * moveSpeed * Time.fixedDeltaTime);
    }

    void Shoot()
    {
        // Spawn projectile
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);

        // Calculate shoot direction
        Vector2 shootDirection = moveInput != Vector2.zero ? moveInput : Vector2.up; // Default to shooting up if idle

        // Assign direction to the projectile
        projectile.GetComponent<Shoot>().SetDirection(shootDirection);
    }
}
