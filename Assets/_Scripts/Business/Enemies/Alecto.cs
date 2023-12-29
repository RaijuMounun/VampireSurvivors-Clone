using UnityEngine;

public class Alecto : BaseEnemy, IEnemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        player = PlayerMovement.Instance.transform;
        rb = GetComponent<Rigidbody>();
        SetStats();
    }

    void SetStats()
    {
        health = EnemyStats.Instance.alectoHealth;
        damage = EnemyStats.Instance.alectoDamage;
        speed = EnemyStats.Instance.alectoSpeed;
        knockbackForce = EnemyStats.Instance.alectoKnockbackForce;
    }

}
