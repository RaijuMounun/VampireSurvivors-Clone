using System.Collections;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float lifeTime;
    public int damage;
    public float speed;
    [HideInInspector] public bool fired = false;


    public PlayerManager player;


    private void OnEnable()
    {
        if (!fired) return;
        transform.parent = null;
        StartCoroutine(DisableAfterDelay());
        player = PlayerManager.Instance;
        transform.LookAt(player.transform);
    }

    IEnumerator DisableAfterDelay()
    {
        yield return new WaitForSeconds(lifeTime);
        fired = false;
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        player.TakeDamage(damage);
        fired = false;
        gameObject.SetActive(false);
    }

    private void FixedUpdate() => transform.Translate(speed * Time.fixedDeltaTime * transform.forward);
}
