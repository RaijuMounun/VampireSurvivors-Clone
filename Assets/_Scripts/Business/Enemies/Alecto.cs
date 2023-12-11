using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alecto : BaseEnemy
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

    // Update is called once per frame
    void Update()
    {

    }
}
