using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TopDownMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    private bool isShooting;

    [Header("Shooting Settings")]
    public GameObject projectilePrefab;
    public Transform shootPoint; // Point from where the projectile spawns
    public float fireRate = 0.5f; // Time between shots

    private Vector2 moveInput;
    private Vector2 lastMoveDirection = Vector2.up; // Default to shooting upward initially
    private float nextFireTime = 0f;

    public bool isOrange;
    public bool isWhite;

    private Animator playerAnimation;


    [Header("Key")]
    public bool[] keys;

    private void Start()
    {
        playerAnimation = gameObject.GetComponent<Animator>();
        if (Cursor.visible)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false; 
        }
        
    }
    void Update()
    {
        // Movement input (only if not shooting)
        if (!isShooting)
        {
            moveInput.x = Input.GetAxis("Horizontal");
            moveInput.y = Input.GetAxis("Vertical");

            // Normalize movement input if necessary
            if (moveInput.sqrMagnitude > 1)
                moveInput = moveInput.normalized;

            // Update the last move direction if the player is moving
            if (moveInput != Vector2.zero)
            {
                lastMoveDirection = moveInput;
            }
        }
        // Update Animator parameters
        playerAnimation.SetFloat("MoveX", moveInput.x);
        playerAnimation.SetFloat("MoveY", moveInput.y);

        // Shooting input
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime && !isShooting)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }


    void FixedUpdate()
    {
        // Move the player (only if not shooting)
        if (!isShooting)
        {
            transform.Translate(moveInput * moveSpeed * Time.fixedDeltaTime);
        }
    }


    void Shoot()
    {
        // Spawn projectile
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);

        // Use the last move direction as the shoot direction
        Vector2 shootDirection = lastMoveDirection;
        Shoot projectileScript = projectile.GetComponent<Shoot>();

        // Assign direction to the projectile
        projectile.GetComponent<Shoot>().SetDirection(shootDirection);

        projectileScript.SetDirection(lastMoveDirection);
        projectileScript.SetShooter(this);
        // Optionally, add a delay to stop shooting
    }

    // Coroutine to reset the shooting state after a small delay (can be adjusted)
    public void ResetShooting()
    {
        isShooting = false;
    }

}
