using UnityEngine;

public class Character : MonoBehaviour
{
    PlayerStats playerStats = PlayerStats.Instance;
    public int Health { get; set; }
    public int Damage { get; set; }
    public bool IsAlive { get; set; }

    void Start()
    {
        Health = playerStats.Health;
        IsAlive = true;
    }


    public void CheckDeath()
    {
        if (Health > 0) return;
        IsAlive = false;
        Death();
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
