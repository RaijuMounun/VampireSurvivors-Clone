using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    BaseGun gun;

    public float lifeTime;
    public int damage;
    public float speed;



    private void OnEnable()
    {
        StartCoroutine(DisableAfterDelay());

        if (GunManager.Instance.activeGun != null)
            gun = GunManager.Instance.activeGun;

        if (gun == null) return;
        lifeTime = gun.BulletLifeTime;
        damage = gun.Damage;
        speed = gun.BulletSpeed;
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
            //collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage); //TODO enemy scripti yaz
        }
        BulletManager.Instance.ReturnBullet(gameObject);
    }

    private void FixedUpdate() => transform.Translate(speed * Time.fixedDeltaTime * transform.forward);
}
