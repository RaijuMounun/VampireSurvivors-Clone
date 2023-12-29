using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletManager : PersistentSingleton<EnemyBulletManager>
{
    [SerializeField] int enemyBulletPoolSize = 100;
    [SerializeField] GameObject enemyBulletPrefab;
    [SerializeField] Transform bulletParent;
    [HideInInspector] public List<GameObject> bulletPool = new();
    int bulletCounter;

    protected override void Awake()
    {
        base.Awake();
        bulletParent = gameObject.transform;
    }
    private void Start()
    {
        ObjectPooler.Instance.CreatePool(enemyBulletPrefab, enemyBulletPoolSize, bulletParent, bulletPool);
    }

    public GameObject SelectBullet()
    {
        GameObject bullet = bulletPool[bulletCounter];
        bulletCounter++;
        if (bulletCounter >= enemyBulletPoolSize) bulletCounter = 0;
        return bullet;
    }
}
