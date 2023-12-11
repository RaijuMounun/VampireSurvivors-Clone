using UnityEngine;

public class PlayerStats : PersistentSingleton<PlayerStats>
{
    public int Health;
    public int Speed;
    public bool IsAlive;
    public float KnockbackForce;


}
