using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Health : MonoBehaviour
{
    public int health = 300;

    public Transform startPos;
    public GameObject GameOver;
    public GameObject Level1;
    public GameObject Level2;
    public TMP_Text healthText;
    public void Start()
    {

    }

    public void TookDamage(int damage)
    {
        health -= damage;
    }
    public void GainHealth(int healthinc)
    {
        health += healthinc;
    }
    private void Update()
    {
        healthText.text = "health:" + health.ToString();
        if (health <= 0)
        {
            Dead();

        }
    }
    public void Dead()
    {
        Level1.SetActive(false);
        Level2.SetActive(false);
        GameOver.SetActive(true);
        Cursor.lockState = CursorLockMode.None; // Unlocks the cursor
        Cursor.visible = true; // Makes it visible
        health = 200;
        gameObject.transform.position = startPos.position;
    }

}