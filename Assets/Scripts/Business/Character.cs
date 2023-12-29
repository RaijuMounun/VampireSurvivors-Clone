using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    PlayerStats playerStats = PlayerStats.Instance;
    public int Health { get; set; }
    public int Damage { get; set; }
    public bool IsAlive { get; set; }

    private void Awake()
    {
        Health = playerStats.Health;
        Damage = playerStats.Damage;
    }
    
    void Start() => IsAlive = true;

    public void CheckDeath()
    {
        if (Health > 0) return;
        IsAlive = false;
        Death();
    }

    void Death() => Destroy(gameObject);
}
