using UnityEngine;

public class EnemySpawner : PersistentSingleton<EnemySpawner>
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform enemyParent;
    [SerializeField] int enemyPoolSize = 20;
    [SerializeField] int waveCounter = 0;


    PlayerMovement player;
    public GameObject[] enemyPool;

    private void Start()
    {
        player = PlayerMovement.Instance;
        MakePool();
        SpawnEnemy(12);
    }

    void MakePool()
    {
        enemyPool = new GameObject[enemyPoolSize];
        for (int i = 0; i < enemyPoolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, enemyParent);
            enemy.SetActive(false);
            enemyPool[i] = enemy;
        }
    }

    public void ReturnEnemy(GameObject enemy) => enemy.SetActive(false);

    public void SpawnEnemy(int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (enemyPool[i].activeInHierarchy) continue;
            enemyPool[i].transform.position = player.transform.position + new Vector3(Random.Range(-80, 80), 0, Random.Range(-80, 80));
            enemyPool[i].SetActive(true);
        }
    }


}
