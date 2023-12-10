using System.Collections;
using UnityEngine;

//TODO reload yap


public class Minigun : BaseGun, IWeapon
{
    private Coroutine firingCoroutine;



    [Header("Minigun Stats")]
    [SerializeField] float spinUpTime = 2f;


    //This area is for serializing fields to control from the inspector
    [SerializeField] int damage = 10, ammo = 100;
    [SerializeField] float range = 20f, fireRate = 0.2f, reloadTime = 2f, bulletSpeed = 2f;
    [SerializeField] bool isReloading, isFiring, isEquipped, isBought;


    private void Start()
    {
        SetUpStats(damage, range, fireRate, bulletSpeed, ammo, reloadTime, isReloading, isFiring, isEquipped, isBought);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) IsFireButtonDown();
        if (Input.GetButtonUp("Fire1")) IsFireButtonUp();
    }

    #region Fire Button Methods
    void IsFireButtonDown()
    {
        IsFiring = true;
        firingCoroutine ??= StartCoroutine(FireAfterDelay());
    }
    void IsFireButtonUp()
    {
        IsFiring = false;
        if (firingCoroutine == null) return;
        StopCoroutine(firingCoroutine);
        firingCoroutine = null;
    }
    #endregion

    #region Firing Methods
    IEnumerator FireAfterDelay()
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
        if (ammo <= 0)
        {
            IsFireButtonUp();
            return;
        }

        print("FIRING FIRING FIRING PEW PEW PEW!!!!");
        ammo--;
        BulletManager.Instance.FireBullet();
    }
    #endregion

}
