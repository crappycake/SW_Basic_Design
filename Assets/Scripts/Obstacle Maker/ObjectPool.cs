using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<List<GameObject>> pooledObjects;
    public List<GameObject> objectToPool;
    public int amountToPool;
    public GameObject objectToAttachTo;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<List<GameObject>>();
        GameObject tmp;
        for (int k = 0; k < objectToPool.Count; k++) {
            Debug.Log(k);
            for (int i = 0; i < amountToPool; i++)
            {
                tmp = Instantiate(objectToPool[k]);
                tmp.transform.SetParent(objectToAttachTo.transform);
                tmp.SetActive(false);
                pooledObjects.Add(new List<GameObject>());
                pooledObjects[k].Add(tmp);
            }
        }
    }

    public GameObject GetPooledObject(int index)
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[index][i].activeInHierarchy)
            {
                return pooledObjects[index][i];
            }
        }
        return null;
    }
}
