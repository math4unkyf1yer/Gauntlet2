using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public Transform startPos;
    public GameObject level1;
    public GameObject level2;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            level2.SetActive(true);
            level1.SetActive(false);
            collision.gameObject.transform.position = startPos.position;
        }
    }
}
