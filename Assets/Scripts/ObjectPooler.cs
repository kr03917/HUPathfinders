using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectPooler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject poolObject;
    public int pooledAmount;
    List<GameObject> pooledObjects;
    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i=0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(poolObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    // Update is called once per frame
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        GameObject obj = (GameObject)Instantiate(poolObject);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }
}
