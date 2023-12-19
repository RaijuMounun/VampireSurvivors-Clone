using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alecto : BaseEnemy, IEnemy
{
    // Start is called before the first frame update
    void Start()
    {
        enemyStats = EnemyStats.Instance;
        player = PlayerMovement.Instance.transform;
        rb = GetComponent<Rigidbody>();
        health = enemyStats.alectoHealth;
        damage = enemyStats.alectoDamage;
        speed = enemyStats.alectoSpeed;
        knockbackForce = PlayerStats.Instance.KnockbackForce;
    }

}
