using UnityEngine;

public class BaseGun : MonoBehaviour
{
    public int Damage { get; set; }
    public float Range { get; set; }
    public float FireRate { get; set; }
    public int Ammo { get; set; }
    public float ReloadTime { get; set; }
    public bool IsReloading { get; set; }
    public bool IsFiring { get; set; }
    public bool IsEquipped { get; set; }
    public bool IsBought { get; set; }




    protected void SetUpStats(int damage, float range, float fireRate, int ammo, float reloadTime, bool isReloading, bool isFiring, bool isEquipped, bool isBought)
    {
        Damage = damage;
        Range = range;
        FireRate = fireRate;
        Ammo = ammo;
        ReloadTime = reloadTime;
        IsReloading = isReloading;
        IsFiring = isFiring;
        IsEquipped = isEquipped;
        IsBought = isBought;
    }
}

public interface IWeapon
{
    void Fire();
}
