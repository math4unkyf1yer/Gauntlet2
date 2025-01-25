using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 200;

    public void TookDamage(int damage)
    {
        health -= damage;
    }
    private void Update()
    {
        if(health <= 0)
        {
            Dead();
        }
    }
    public void Dead()
    {

    }
}
