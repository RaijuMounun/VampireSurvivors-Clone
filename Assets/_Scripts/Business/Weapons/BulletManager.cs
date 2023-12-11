using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : PersistentSingleton<BulletManager>
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletParent;
    [SerializeField] int bulletPoolSize = 20;


    PlayerMovement player;
    public List<GameObject> bulletPool2 = new();
    int bulletCounter = 0;

    protected override void Awake() => base.Awake();
    private void Start()
    {
        player = PlayerMovement.Instance;
        StartCoroutine(Delay(1f));
    }

    IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
        MakePool();
    }

    void MakePool()
    {
        for (int i = 0; i < bulletPoolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletParent);
            bullet.SetActive(false);
            bulletPool2.Add(bullet);
        }
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
    }


    public void FireBullet()
    {
        if (bulletPool2.Count <= 0)
        {
            MakePool();
            FireBullet();
            return;
        }

        GoLittleBullet();
    }


    void GoLittleBullet()
    {
        GameObject bullet = bulletPool2[bulletCounter];
        bulletCounter++;
        if (bulletCounter >= bulletPoolSize) bulletCounter = 0;
        bullet.transform.position = player.transform.position;
        bullet.transform.localRotation = player.transform.rotation;
        bullet.SetActive(true);
    }


}
