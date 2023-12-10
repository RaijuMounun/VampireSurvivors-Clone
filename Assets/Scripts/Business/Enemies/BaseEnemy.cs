using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : Character
{
    [Header("Enemy Stats")]
    public int health;
    public int damage;




    private void Awake()
    {
        Health = health;
        Damage = damage;
    }


    public void TakeDamage(int damage)
    {
        Health -= damage;
        CheckDeath();
    }
}
