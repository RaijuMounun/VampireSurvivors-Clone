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


    [Header("Ctesiphon Stats")]
    public int ctesiphonHealth = 100;
    public int ctesiphonDamage = 10;
    public int ctesiphonSpeed = 5;
    public float ctesiphonKnockbackForce = 10f;
    public float ctesiphonAttackRange = 5f;
    public float ctesiphonAttackCooldown = 1f;
    public int ctesiphonBulletPoolSize = 20;


}
