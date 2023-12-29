using System.Collections;
using UnityEngine;

//TODO reload yap


public class Minigun : BaseGun, IWeapon
{
    private Coroutine firingCoroutine;


    [Header("Minigun Stats")]
    public float spinUpTime = 2f;
    public int damage = 10, currentAmmo = 100, maxAmmo = 100;
    public float range = 20f, fireRate = 0.2f, reloadTime = 2f, bulletSpeed = 2f;
    public bool isReloading, isFiring, isEquipped, isBought;


    private void Start()
    {
        SetUpStats(damage, range, fireRate, bulletSpeed, currentAmmo, maxAmmo, reloadTime, isReloading, isFiring, isEquipped, isBought, firingCoroutine);
    }


    #region Firing Methods
    public override void StartFire() => FiringCoroutine ??= StartCoroutine(FireCoroutine());

    public IEnumerator FireCoroutine()
    {
        yield return new WaitForSeconds(spinUpTime);
        while (IsFiring)
        {
            Fire();
            yield return new WaitForSeconds(FireRate);
        }
    }

    public void Fire()
    {
        if (currentAmmo <= 0)
        {
            GunManager.Instance.IsFireButtonUp();
            return;
        }
        currentAmmo--;
        BulletManager.Instance.FireBullet();
    }
    #endregion


}
