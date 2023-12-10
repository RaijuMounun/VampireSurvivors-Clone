using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    BaseGun gun;

    public float lifeTime;
    public int damage;
    public float speed;


    public Vector3 direction;



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
        if (collision.GetType() == typeof(BaseEnemy))
        {
            //collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage); //TODO enemy scripti yaz
            BulletManager.Instance.ReturnBullet(gameObject);
        }
    }

    private void FixedUpdate() => transform.Translate(speed * Time.fixedDeltaTime * transform.forward, Space.Self);

}
