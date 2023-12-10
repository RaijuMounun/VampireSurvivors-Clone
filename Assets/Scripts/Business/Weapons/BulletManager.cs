using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : PersistentSingleton<BulletManager>
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletParent;
    [SerializeField] int bulletPoolSize = 20;


    PlayerMovement player;

    Queue<GameObject> bulletPool;
    public List<GameObject> bulletPool2 = new();
    int bulletCounter = 0;

    protected override void Awake() => base.Awake();
    private void Start()
    {
        player = PlayerMovement.Instance;
        bulletPool = new Queue<GameObject>(bulletPoolSize);
        MakePool();
    }

    void MakePool()
    {
        for (int i = 0; i < bulletPoolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletParent);
            bullet.SetActive(false);
            bulletPool2.Add(bullet);
            bulletPool.Enqueue(bullet);
        }
    }

    public GameObject GetBullet()
    {
        if (bulletPool.Count <= 0)
        {
            MakePool();
            return GetBullet();
        }

        GameObject bullet = bulletPool.Dequeue();
        bullet.SetActive(true);
        return bullet;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }


    public void FireBullet()
    {
        if (bulletPool.Count <= 0)
        {
            MakePool();
            FireBullet();
            return;
        }

        GameObject bullet = bulletPool2[bulletCounter];
        bulletCounter++;
        if (bulletCounter >= bulletPoolSize) bulletCounter = 0;
        bullet.transform.position = player.transform.position;
        bullet.transform.LookAt(player.worldPos);
        bullet.SetActive(true);
    }



}
