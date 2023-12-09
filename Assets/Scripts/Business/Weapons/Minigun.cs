using System.Collections;
using UnityEngine;

public class Minigun : BaseGun, IWeapon
{
    [Header("Minigun Stats")]
    [SerializeField] float spinUpTime = 2f;


    //This area is for serializing fields to control from the inspector
    [SerializeField] int damage = 10, ammo = 100;
    [SerializeField] float range = 20f, fireRate = 0.2f, reloadTime = 2f;
    [SerializeField] bool isReloading, isFiring, isEquipped, isBought;



    private Coroutine firingCoroutine;



    private void Awake()
    {
        SetUpStats();
    }

    void Update()
    {
        IsFireButtonDown();
        IsFireButtonUp();
    }




    void SetUpStats()
    {
        Damage = damage;
        Range = range;
        FireRate = fireRate;
        Ammo = ammo;
        ReloadTime = reloadTime;
        IsReloading = false;
        IsFiring = false;
        IsEquipped = false;
        IsBought = false;
    }

    void IsFireButtonDown()
    {
        if (!Input.GetButtonDown("Fire1")) return;
        IsFiring = true;
        firingCoroutine ??= StartCoroutine(FireAfterDelay());
    }
    void IsFireButtonUp()
    {
        if (!Input.GetButtonUp("Fire1")) return;
        IsFiring = false;
        if (firingCoroutine == null) return;
        StopCoroutine(firingCoroutine);
        firingCoroutine = null;
    }

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
        print("FIRING FIRING FIRING PEW PEW PEW!!!!");
    }

}
