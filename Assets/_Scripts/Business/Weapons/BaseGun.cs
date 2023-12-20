using UnityEngine;

public class BaseGun : MonoBehaviour, IWeapon
{
    public Coroutine FiringCoroutine;



    public int Damage { get; set; }
    public float BulletLifeTime { get; set; }
    public float FireRate { get; set; }
    public float BulletSpeed { get; set; }
    public int CurrentAmmo { get; set; }
    public int MaxAmmo { get; set; }
    public float ReloadTime { get; set; }
    public bool IsReloading { get; set; }
    public bool IsFiring { get; set; }
    public bool IsEquipped { get; set; }
    public bool IsBought { get; set; }




    protected void SetUpStats(int damage, float bulletLifeTime, float fireRate, float bulletSpeed, int currentAmmo, int maxAmmo, float reloadTime, bool isReloading, bool isFiring, bool isEquipped, bool isBought, Coroutine firingCoroutine)
    {
        Damage = damage;
        BulletLifeTime = bulletLifeTime;
        FireRate = fireRate;
        BulletSpeed = bulletSpeed;
        CurrentAmmo = currentAmmo;
        MaxAmmo = maxAmmo;
        ReloadTime = reloadTime;
        IsReloading = isReloading;
        IsFiring = isFiring;
        IsEquipped = isEquipped;
        IsBought = isBought;
        FiringCoroutine = firingCoroutine;
    }

    public virtual void StartFire() { }
    public void Reload() { }
}

public interface IWeapon
{
    void StartFire();
    void Reload();
}
