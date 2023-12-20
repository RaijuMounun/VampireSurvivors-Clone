using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    BaseGun gun;

    public float lifeTime;
    public int damage;
    public float speed;




    private void OnEnable()
    {
        gun = GunManager.Instance.activeGun;
        lifeTime = gun.BulletLifeTime;
        damage = gun.Damage;
        speed = gun.BulletSpeed;

        StartCoroutine(DisableAfterDelay());

    }

    IEnumerator DisableAfterDelay()
    {
        yield return new WaitForSeconds(lifeTime);
        BulletManager.Instance.ReturnBullet(gameObject);
    }

    private void OnDisable() => StopAllCoroutines();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            BaseEnemy enemySc = collision.gameObject.GetComponent<BaseEnemy>();
            enemySc.TakeDamage(damage);
            BulletManager.Instance.ReturnBullet(gameObject);
        }
    }

    private void FixedUpdate() => transform.Translate(speed * Time.fixedDeltaTime * transform.forward, Space.World);

}
