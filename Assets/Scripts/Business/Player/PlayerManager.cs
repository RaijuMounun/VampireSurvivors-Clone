using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : PersistentSingleton<PlayerManager>
{
    PlayerStats playerStats;

    [Header("Player Stats")]
    public int baseHealth = 100;
    public int baseSpeed = 5;
    public float baseKnockbackForce = 10f;

    private void Start()
    {
        playerStats = PlayerStats.Instance;
        playerStats.Health = baseHealth;
        playerStats.Speed = baseSpeed;
        playerStats.IsAlive = true;
        playerStats.KnockbackForce = baseKnockbackForce;
    }


    public void TakeDamage(int damage)
    {
        playerStats.Health -= damage;
        CheckDeath();
    }
    void CheckDeath()
    {
        if (playerStats.Health <= 0)
        {
            playerStats.IsAlive = false;
            Debug.Log("Player is dead");
        }
    }
}
