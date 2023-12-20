using System.Collections.Generic;
using UnityEngine;

public class BulletManager : PersistentSingleton<BulletManager>
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletParent;
    [SerializeField] int bulletPoolSize = 20;


    PlayerMovement player;
    public List<GameObject> bulletPool = new List<GameObject>();
    int bulletCounter = 0;

    protected override void Awake() => base.Awake();
    private void Start() => player = PlayerMovement.Instance;


    public void ReturnBullet(GameObject bullet) => bullet.SetActive(false);


    public void FireBullet()
    {
        IfAmmoOut();
        GoLittleBullet();
    }


    void IfAmmoOut()
    {
        if (bulletPool.Count > 0) return;
        ObjectPooler.Instance.CreatePool(bulletPrefab, bulletPoolSize, bulletParent, bulletPool);
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
