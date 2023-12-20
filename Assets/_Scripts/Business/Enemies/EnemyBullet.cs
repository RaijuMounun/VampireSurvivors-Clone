using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float lifeTime;
    public int damage;
    public float speed;

    Transform parent;

    public PlayerManager player;


    private void OnEnable()
    {
        parent = transform.parent;
        transform.parent = null;
        StartCoroutine(DisableAfterDelay());
        player = PlayerManager.Instance;
        transform.LookAt(player.transform);
    }

    IEnumerator DisableAfterDelay()
    {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        StopAllCoroutines();
        transform.parent = parent;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        player.TakeDamage(damage);
        gameObject.SetActive(false);
    }

    private void FixedUpdate() => transform.Translate(speed * Time.fixedDeltaTime * transform.forward);
}
