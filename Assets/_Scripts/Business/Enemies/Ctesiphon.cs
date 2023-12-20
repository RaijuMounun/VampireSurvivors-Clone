using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctesiphon : BaseEnemy, IEnemy
{

    [SerializeField] GameObject enemyBulletPrefab;
    [SerializeField] Transform bulletParent;
    int bulletPoolSize;
    [HideInInspector] public List<GameObject> bulletPool = new();
    int bulletCounter;

    SphereCollider rangeCollider;
    bool inRange;

    private Coroutine firingCoroutine;
    float attackCooldown;



    void Start()
    {
        SetStats();

        ObjectPooler.Instance.CreatePool(enemyBulletPrefab, bulletPoolSize, bulletParent, bulletPool);
    }

    void SetStats()
    {
        enemyStats = EnemyStats.Instance;
        player = PlayerMovement.Instance.transform;
        rb = GetComponent<Rigidbody>();

        health = enemyStats.ctesiphonHealth;
        damage = enemyStats.ctesiphonDamage;
        speed = enemyStats.ctesiphonSpeed;

        knockbackForce = PlayerStats.Instance.KnockbackForce;
        bulletPoolSize = enemyStats.ctesiphonBulletPoolSize;
        rangeCollider = GetComponent<SphereCollider>();
        rangeCollider.radius = enemyStats.ctesiphonAttackRange;
        attackCooldown = enemyStats.ctesiphonAttackCooldown;
    }


    void Update()
    {
        Move();
        transform.LookAt(player);
    }

    public override void Move()
    {
        if (!isAlive || inRange) return;
        // Move towards the player
        direction = (player.position - transform.position).normalized;
        rb.MovePosition(transform.position + speed * Time.deltaTime * direction);
    }

    #region OnTrigger, OnCollision Enter-Exit
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") || !isAlive) return;
        inRange = true;
        StartFire();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || !isAlive) return;
        inRange = false;
        StopCoroutine(firingCoroutine);
        //firingCoroutine = null;
    }
    #endregion

    #region Attack
    public void StartFire() => firingCoroutine ??= StartCoroutine(FireCoroutine());
    public IEnumerator FireCoroutine()
    {
        while (inRange)
        {
            Fire();
            yield return new WaitForSeconds(attackCooldown);
        }
    }
    public void Fire()
    {
        GameObject bullet = bulletPool[bulletCounter];
        bulletCounter++;
        if (bulletCounter >= bulletPoolSize) bulletCounter = 0;
        bullet.transform.SetPositionAndRotation(transform.position, transform.rotation);
        bullet.SetActive(true);
    }
    #endregion


}
