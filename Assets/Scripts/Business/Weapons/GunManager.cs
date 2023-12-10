using System.Collections;
using System.Collections.Generic;
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
}

public enum ActiveGun
{
    Minigun,
    AddOtherGuns
}