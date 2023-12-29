using UnityEngine;

public class EnemyStats : PersistentSingleton<EnemyStats>
{
    [Header("Base Enemy Stats")]
    [Range(0, 500)] public int baseHealth = 100;
    [Range(0, 100)] public int baseDamage = 10;
    [Range(0, 50)] public float baseSpeed = 5f;
    [Range(0, 100)] public float baseKnockbackForce = 10f;


    [Header("Alecto Stats")]
    [Range(0, 500)] public int alectoHealth = 100;
    [Range(0, 100)] public int alectoDamage = 10;
    [Range(0, 50)] public int alectoSpeed = 5;
    [Range(0, 100)] public float alectoKnockbackForce = 10f;


    [Header("Ctesiphon Stats")]
    [Range(0, 500)] public int ctesiphonHealth = 100;
    [Range(0, 100)] public int ctesiphonDamage = 10;
    [Range(0, 50)] public float ctesiphonSpeed = 5f;
    [Range(0, 100)] public float ctesiphonKnockbackForce = 10f;
    [Range(0, 100)] public float ctesiphonAttackRange = 5f;
    [Range(0, 10)] public float ctesiphonAttackCooldown = 1f;


}
