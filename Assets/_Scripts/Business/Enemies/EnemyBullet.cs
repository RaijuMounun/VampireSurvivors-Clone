using System.Collections;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float lifeTime;
    public int damage;
    public float speed;

    PlayerManager player;

    private void Start() => player = PlayerManager.Instance;

    private void OnEnable() => StartCoroutine(DisableAfterDelay());

    IEnumerator DisableAfterDelay()
    {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }
    private void OnDisable() => StopAllCoroutines();

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        player.TakeDamage(damage);
        gameObject.SetActive(false);
    }

    private void FixedUpdate() => transform.Translate(speed * Time.fixedDeltaTime * transform.forward, Space.World);
}
