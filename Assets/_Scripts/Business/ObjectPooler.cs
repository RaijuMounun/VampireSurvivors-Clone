using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : PersistentSingleton<ObjectPooler>
{
    public void CreatePool(GameObject prefab, int poolSize, Transform parent, List<GameObject> pool)
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab, parent);
            StartCoroutine(DisableAfterDelay(obj, 0.1f));
            pool.Add(obj);
        }
    }

    IEnumerator DisableAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(false);
    }
}
