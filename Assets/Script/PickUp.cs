using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject Win;
    public GameObject Level1;
    public GameObject Level2;
    public int keyNb;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "Key")
            {
                TopDownMovement movementScript = collision.gameObject.GetComponent<TopDownMovement>();
                movementScript.keys[keyNb] = true;
                Destroy(gameObject);
            }
            if (gameObject.tag == "Health")
            {
                Health healthScript = collision.gameObject.GetComponent<Health>();
                healthScript.GainHealth(50);
                Destroy(gameObject);
            }
            if (gameObject.tag == "Win")
            {
                Win.SetActive(true);
                Level1.SetActive(false);
                Level2.SetActive(false);
                Cursor.lockState = CursorLockMode.None; // Unlocks the cursor
                Cursor.visible = true; // Makes it visible
            }
        }
    }
}
