using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : PersistentSingleton<BulletManager>
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletParent;
    [SerializeField] int bulletPoolSize = 20;


    PlayerMovement player;
    public List<GameObject> bulletPool = new();
    int bulletCounter = 0;

    protected override void Awake() => base.Awake();
    private void Start() => player = PlayerMovement.Instance;

    void MakePool()
    {
        for (int i = 0; i < bulletPoolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletParent);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }

    public void ReturnBullet(GameObject bullet) => bullet.SetActive(false);


    public void FireBullet()
    {
        IfAmmoOut();
        GoLittleBullet();
    }


    void IfAmmoOut()
    {
        if (bulletPool.Count > 0) return;
        MakePool();
        FireBullet();
    }


    void GoLittleBullet()
    {
        GameObject bullet = bulletPool[bulletCounter];
        bulletCounter++;
        if (bulletCounter >= bulletPoolSize) bulletCounter = 0;
        bullet.transform.position = player.transform.position;
        bullet.transform.localRotation = player.transform.rotation;
        bullet.SetActive(true);
    }


}
