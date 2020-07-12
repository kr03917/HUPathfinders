using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public ObjectPooler coinPool;
    public float distanceBetweenCoins;
    
    public void spawnCoins (Vector3 startPosition)
    {
        GameObject coin1 = coinPool.GetPooledObject();
        coin1.transform.position = startPosition;
        coin1.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
