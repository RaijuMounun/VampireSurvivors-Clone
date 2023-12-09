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
}

public interface IWeapon
{
    void Fire();
}
