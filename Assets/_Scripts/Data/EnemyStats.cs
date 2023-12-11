using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : PersistentSingleton<EnemyStats>
{
    [Header("Base Enemy Stats")]
    public int baseHealth = 100;
    public int baseDamage = 10;
    public int baseSpeed = 5;
    public float baseKnockbackForce = 10f;


    [Header("Alecto Stats")]
    public int alectoHealth = 100;
    public int alectoDamage = 10;
    public int alectoSpeed = 5;
    public float alectoKnockbackForce = 10f;

}
