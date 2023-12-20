using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Ctesiphon : BaseEnemy, IEnemy
{
    [SerializeField] GameObject enemyBulletPrefab;
    int bulletPoolSize;
    public List<GameObject> bulletPool = new();

    SphereCollider rangeCollider;
    bool inRange;



    void Start()
    {
        enemyStats = EnemyStats.Instance;
        player = PlayerMovement.Instance.transform;
        rb = GetComponent<Rigidbody>();
        health = enemyStats.alectoHealth;
        damage = enemyStats.alectoDamage;
        speed = enemyStats.alectoSpeed;
        knockbackForce = PlayerStats.Instance.KnockbackForce;
        bulletPoolSize = enemyStats.ctesiphonBulletPoolSize;
        rangeCollider = GetComponent<SphereCollider>();
        rangeCollider.radius = enemyStats.ctesiphonAttackRange;

        ObjectPooler.Instance.CreatePool(enemyBulletPrefab, bulletPoolSize, transform.parent, bulletPool);
    }


    public override void Move()
    {
        if (!isAlive || inRange) return;
        // Move towards the player
        direction = (player.position - transform.position).normalized;
        rb.MovePosition(transform.position + speed * Time.deltaTime * direction);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) inRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) inRange = false;
    }


    //TODO ateş ettir


}
