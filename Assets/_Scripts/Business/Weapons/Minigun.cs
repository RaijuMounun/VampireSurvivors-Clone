using System.Collections;
using UnityEngine;

//TODO reload yap


public class Minigun : BaseGun, IWeapon
{
    private Coroutine firingCoroutine;



    [Header("Minigun Stats")]
    [SerializeField] float spinUpTime = 2f;


    //This area is for serializing fields to control from the inspector
    [SerializeField] int damage = 10, currentAmmo = 100, maxAmmo = 100;
    [SerializeField] float range = 20f, fireRate = 0.2f, reloadTime = 2f, bulletSpeed = 2f;
    [SerializeField] bool isReloading, isFiring, isEquipped, isBought;


    private void Start()
    {
        SetUpStats(damage, range, fireRate, bulletSpeed, currentAmmo, maxAmmo, reloadTime, isReloading, isFiring, isEquipped, isBought, firingCoroutine);
    }


    #region Firing Methods

    new public void StartFire()
    {
        print("Start Fire");
        FiringCoroutine ??= StartCoroutine(FireCoroutine());
    }
    public IEnumerator FireCoroutine()
    {
        print("Fire");
        yield return new WaitForSeconds(spinUpTime);
        while (IsFiring)
        {
            FireAfterDelay();
            yield return new WaitForSeconds(FireRate);
        }
    }

    public void FireAfterDelay()
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
