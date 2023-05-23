using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
// This class is used to store information about what objects to pool and how many
class ObjectPoolItem
{
    public GameObject prefab;
    public int amountToPool = 10;
    public bool shouldExpand = false;

    [HideInInspector]
    public List<GameObject> pooledObjects;
}


public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;

    public GameObject parentObject;

    [SerializeField] List<ObjectPoolItem> objectPoolItems;


    Dictionary<string,  ObjectPoolItem> pools;

    private void Awake()
    {
        SharedInstance = this;
        pools = new Dictionary<string, ObjectPoolItem>();

    }

    private void Start()
    {

        // Create a dictionary of pools
        foreach (ObjectPoolItem item in objectPoolItems)
        {
            item.pooledObjects = new List<GameObject>();
            for (int i = 0; i < item.amountToPool; i++)
            {
                GameObject obj = Instantiate(item.prefab, parentObject.transform);
                obj.SetActive(false);
                item.pooledObjects.Add(obj);
            }

            pools.Add(item.prefab.name, item);
        }

    }

    // This method is used to get an object from the pool
    public GameObject GetPooledObject(string tag)
    {
        if (!pools.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
            return null;
        }

        ObjectPoolItem pool = pools[tag];

        for (int i = 0; i < pool.pooledObjects.Count; i++)
        {
            if (!pool.pooledObjects[i].activeInHierarchy)
            {
                return pool.pooledObjects[i];
            }
        }

        if (pool.shouldExpand)
        {
            GameObject obj = Instantiate(pool.prefab);
            obj.SetActive(false);
            pool.pooledObjects.Add(obj);
            return obj;
        }

        return null;
    }

}

