using System.Linq;
using UnityEngine;

public class EnemySpawner : PersistentSingleton<EnemySpawner>
{
    [SerializeField] int enemyPoolSize = 20;
    [SerializeField] int waveCounter = 0;


    PlayerMovement player;
    public GameObject[] baseEnemyPool, alectoPool;
    public GameObject[][] enemyPools;

    public GameObject[] enemyTypes;
    public Transform[] enemyParents;


    public int SpawnEnemyCount => enemyPools[0].Where(x => x.activeInHierarchy).Count();

    private void Start()
    {
        enemyPools = new GameObject[enemyTypes.Length][];
        enemyPools[0] = baseEnemyPool;
        enemyPools[1] = alectoPool;
        player = PlayerMovement.Instance;
        MakePool();
        SpawnEnemy(3, 0);
        SpawnEnemy(3, 1);
    }

    void MakePool()
    {
        enemyPools = enemyTypes.Select((enemyType, j) =>
        {
            var pool = new GameObject[enemyPoolSize];
            for (int i = 0; i < enemyPoolSize; i++)
            {
                GameObject enemy = Instantiate(enemyType, enemyParents[j]);
                enemy.SetActive(false);
                pool[i] = enemy;
            }
            return pool;
        }).ToArray();
    }

    public void ReturnEnemy(GameObject enemy) => enemy.SetActive(false);

    public void SpawnEnemy(int count, int enemyType)
    {
        var enemiesToSpawn = enemyPools[enemyType]
        .Where(enemy => !enemy.activeInHierarchy)
        .Take(count);

        foreach (var enemy in enemiesToSpawn)
        {
            enemy.transform.position = player.transform.position + new Vector3(Random.Range(-80, 80), 0, Random.Range(-80, 80));
            enemy.SetActive(true);
        }
    }


}
