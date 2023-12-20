using System.Linq;
using UnityEngine;

public class EnemySpawner : PersistentSingleton<EnemySpawner>
{
    [SerializeField] int enemyPoolSize = 20;
    [SerializeField] int waveCounter = 0;


    PlayerMovement player;
    public GameObject[] baseEnemyPool, alectoPool, ctesiphonPool;
    public GameObject[][] enemyPools;

    public GameObject[] enemyTypes;
    public Transform[] enemyParents;


    [Header("Enemy Spawn Counts")]
    public int baseEnemySpawnCount;
    public int alectoSpawnCount;
    public int ctesiphonSpawnCount;


    public int SpawnEnemyCount => enemyPools[0].Where(x => x.activeInHierarchy).Count();

    private void Start()
    {
        enemyPools = new GameObject[enemyTypes.Length][];
        enemyPools[0] = baseEnemyPool; //TODO: enemyleri ekle buraya
        enemyPools[1] = alectoPool;
        enemyPools[2] = ctesiphonPool;
        player = PlayerMovement.Instance;
        MakePool();
        SpawnEnemy(baseEnemySpawnCount, 0);
        SpawnEnemy(alectoSpawnCount, 1);
        SpawnEnemy(ctesiphonSpawnCount, 2);
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
