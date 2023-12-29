using System;
using System.Collections;
using UnityEngine;

/*
Scale of unity
One prince of rebellion, of angels, and darkness:
Lucifer

Scale of binary
Two chiefs of the devils:
Behemoth
Leviathan

Scale of ternary
Three furies:
Alecto
Megera
Ctesiphon

Three infernal judges:
Minos
Aeacus
Rhadamanthus

Scale of quaternary
Four Princes of devils in the elements:
Samael: Fire
Azazel: Air
Azrael: Water
Mahazael: Earth

Four Princes of spirits, upon the four angles of the world
Oriens: East
Paymon: West
Egyn: North
Amaymon: South

Scale of six
Six authors of all calamities:
Acteus
Megalesius
Ormenus
Lycus
Nicon
Mimon

Scale of novenary
Nine princes ruling over nine orders of devils (with biblical references):
Beelzebub: False Gods (Matthew 4:1–11)
Python: Spirits of Lying (1 Kings 22:21–22)
Belial: Instruments of iniquity and wrath (Genesis 49:5, Psalms 7:13, Isaiah 13:5, Jeremiah 50:25, Ezekiel 9:2)
Asmodeus: Revengers of Wickedness
Satan: Deluders or Imitators of miracles (Genesis 3:1–5)
Merihem: Aerial Powers (Revelation 7:1–2)
Abaddon: Furies – sowing mischief
Astaroth: Calumniators – inquisitors and accusers
Mammon: evil genies – tempters and ensnarers
*/



public class BaseEnemy : Character, IEnemy
{
    [HideInInspector] public Transform player;
    [HideInInspector] public Rigidbody rb;

    [Header("Enemy Stats")]
    public int health;
    [HideInInspector] public int damage;
    [HideInInspector] public float speed;
    [HideInInspector] public float knockbackForce;
    public bool isAlive = true;

    //Movement
    public Vector3 direction;
    int counter;



    protected virtual void Start()
    {
        player = PlayerMovement.Instance.transform;
        rb = GetComponent<Rigidbody>();
        SetStats();
    }

    void Update()
    {
        DelayUpdate(60, Move);
    }

    void DelayUpdate(int frameCount, Action function)
    {
        if (++counter % frameCount != 0) return;

        function();
    }


    void SetStats()
    {
        health = EnemyStats.Instance.baseHealth;
        damage = EnemyStats.Instance.baseDamage;
        speed = EnemyStats.Instance.baseSpeed;
        knockbackForce = EnemyStats.Instance.baseKnockbackForce;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Attack(collision);
    }

    public virtual void Move()
    {
        if (!isAlive) return;
        // Move towards the player
        direction = (player.position - transform.position).normalized;
        rb.MovePosition(transform.position + speed * Time.deltaTime * direction);
    }

    public void Attack(Collision collision)
    {
        if (!isAlive || !collision.gameObject.CompareTag("Player")) return;

        // Apply knockback
        Vector3 knockbackDirection = (transform.position - player.position).normalized;
        rb.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);

        // Deal damage
        PlayerManager.Instance.TakeDamage(damage);
    }

    public virtual void Attack() { }


    #region TakeDamage and Death
    public void TakeDamage(int damage)
    {
        print(name + " took " + damage + " damage");
        health -= damage;
        CheckDeath();
    }
    new void CheckDeath()
    {
        if (Health > 0) return;
        isAlive = false;
        StartCoroutine(Death());
    }
    IEnumerator Death()
    {
        yield return new WaitForSeconds(1f);
        EnemySpawner.Instance.ReturnEnemy(gameObject);
    }
    #endregion
}

interface IEnemy
{
    void Move();
    void TakeDamage(int damage);
    void CheckDeath();
    void Attack(Collision collision);
}