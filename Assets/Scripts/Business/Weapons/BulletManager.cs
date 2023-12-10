using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : PersistentSingleton<BulletManager>
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletParent;
    [SerializeField] int bulletPoolSize = 20;



}
