using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : PersistentSingleton<ObjectPooler>
{
    public void CreatePool(GameObject prefab, int poolSize, Transform parent, List<GameObject> pool)
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab, parent);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }
}
