using System.Collections;
using UnityEngine;

public class GunManager : PersistentSingleton<GunManager>
{
    public ActiveGun activeGunEnum = ActiveGun.AddOtherGuns;
    public BaseGun activeGun;



    [Header("Gun GameObjects")]
    [SerializeField] Minigun minigun;

    protected override void Awake()
    {
        base.Awake();
        ChangeActiveGun(ActiveGun.Minigun);
    }

    public void ChangeActiveGun(ActiveGun gun)
    {
        activeGunEnum = gun;
        switch (gun)
        {
            case ActiveGun.Minigun:
                activeGun = minigun;
                break;
            case ActiveGun.AddOtherGuns:
                break;
            default:
                break;
        }
    }


    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) IsFireButtonDown();
        if (Input.GetButtonUp("Fire1")) IsFireButtonUp();
        if (Input.GetKeyDown(KeyCode.R)) Reload();
    }

    #region Firing Methods
    void IsFireButtonDown()
    {
        if (activeGun.IsReloading) return;
        activeGun.IsFiring = true;
        print(activeGun.IsReloading);
        activeGun.StartFire();
    }
    public void IsFireButtonUp()
    {
        activeGun.IsFiring = false;
        if (activeGun.FiringCoroutine == null) return;
        StopCoroutine(activeGun.FiringCoroutine);
        activeGun.FiringCoroutine = null;
    }
    #endregion

    #region Reloading Methods
    public void Reload()
    {
        if (activeGun.CurrentAmmo == activeGun.MaxAmmo) return;
        activeGun.IsReloading = true;
        StartCoroutine(ReloadAfterDelay());
    }

    IEnumerator ReloadAfterDelay()
    {
        yield return new WaitForSeconds(activeGun.ReloadTime);
        activeGun.CurrentAmmo = activeGun.MaxAmmo;
        activeGun.IsReloading = false;
    }
    #endregion

}

public enum ActiveGun
{
    Minigun,
    AddOtherGuns
}