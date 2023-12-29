using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    BaseGun gun;

    public float lifeTime;
    public int damage;
    public float speed;
    public Transform parent;
    Vector3 direction;




    private void OnEnable()
    {
        gun = GunManager.Instance.activeGun;
        lifeTime = gun.BulletLifeTime;
        damage = gun.Damage;
        speed = gun.BulletSpeed;
        parent = BulletManager.Instance.bulletParent;
        direction = (PlayerMovement.Instance.gameObject.transform.position - PlayerMovement.Instance.mousePosObj.position).normalized;

        StartCoroutine(DisableAfterDelay());
    }

    IEnumerator DisableAfterDelay()
    {
        yield return new WaitForSeconds(lifeTime);
        transform.SetParent(parent);
        BulletManager.Instance.ReturnBullet(gameObject);
    }

    private void OnDisable() => StopAllCoroutines();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            BaseEnemy enemySc = collision.gameObject.GetComponent<BaseEnemy>();
            enemySc.TakeDamage(damage);
            transform.SetParent(parent);
            BulletManager.Instance.ReturnBullet(gameObject);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(speed * Time.fixedDeltaTime * direction);
    }
}
