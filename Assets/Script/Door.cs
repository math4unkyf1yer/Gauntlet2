using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int doorNb;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            TopDownMovement movementScript = collision.gameObject.GetComponent<TopDownMovement>();
            if(movementScript.keys[doorNb] == true)
            {
                Destroy(gameObject);
            }
        }
    }
}
