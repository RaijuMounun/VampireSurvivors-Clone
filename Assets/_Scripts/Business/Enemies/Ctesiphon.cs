using System.Collections;
using UnityEngine;

public class Ctesiphon : BaseEnemy, IEnemy
{
    SphereCollider rangeCollider;
    bool inRange;

    private Coroutine firingCoroutine;
    [SerializeField] float attackCooldown;



    protected override void Start()
    {
        rangeCollider = GetComponent<SphereCollider>();
        player = PlayerMovement.Instance.transform;
        rb = GetComponent<Rigidbody>();
        SetStats();
    }


    void SetStats()
    {
        health = EnemyStats.Instance.ctesiphonHealth;
        damage = EnemyStats.Instance.ctesiphonDamage;
        speed = EnemyStats.Instance.ctesiphonSpeed;
        knockbackForce = EnemyStats.Instance.ctesiphonKnockbackForce;
        rangeCollider.radius = EnemyStats.Instance.ctesiphonAttackRange;
        attackCooldown = EnemyStats.Instance.ctesiphonAttackCooldown;
    }


    void Update()
    {
        Move();
        transform.LookAt(player);
    }

    public override void Move()
    {
        if (!isAlive || inRange) return;
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
        GameObject bullet = EnemyBulletManager.Instance.SelectBullet();
        bullet.transform.SetPositionAndRotation(transform.position, transform.rotation);
        bullet.GetComponent<EnemyBullet>().fired = true;
        bullet.SetActive(true);
    }
    #endregion


}
