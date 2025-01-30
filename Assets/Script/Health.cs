using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public int health = 200;

    public Transform startPos;

    [Header("Text")]
    public TextMeshProUGUI playerHealth;

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
        playerHealth.text = "Health:" + health.ToString();
        if (health <= 0)
        {
            Dead();
        }
    }
    public void Dead()
    {
        //go back to menu
    }
}
