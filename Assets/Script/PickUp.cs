using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public int keyNb;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            TopDownMovement movementScript = collision.gameObject.GetComponent<TopDownMovement>();
            movementScript.keys[keyNb] = true;
            Destroy(gameObject);
        }
    }
}
