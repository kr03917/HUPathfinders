using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;
    private float platformWidth;
    public ObjectPooler theObjectPool;
    private CoinGenerator theCoinGenerator;
    public float randomCoinThreshold;
    public float randomSpikeThreshold;
   // public ObjectPooler theSpikePool;
    public ObjectPooler theAssignmentPool;
    private float powerUpHeight;
    public ObjectPooler powerUpPool;
    public float powerUpThreshold;
    public float assignmentThreshold;
    float time = 100;
    // Start is called before the first frame update
    void Start()
    {
        platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
        theCoinGenerator = FindObjectOfType<CoinGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth, transform.position.y, transform.position.z);
            GameObject newPlatform = theObjectPool.GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            //newPlatform.SetActive(true);
            
            bool coin, power, assignment;
            coin = Random.Range(0f, 100f) < randomCoinThreshold;
            //spike = Random.Range(0f, 100f) < randomSpikeThreshold;
            power = Random.Range(0f, 100f) < powerUpThreshold;
            assignment = Random.Range(0f, 100f) < assignmentThreshold;
            float spikeXposition = Random.Range(-platformWidth / 2f, platformWidth / 2f);

            if (assignment)
            {
                GameObject newAssignment = theAssignmentPool.GetPooledObject();
                newAssignment.transform.position = transform.position + new Vector3(0f, 1f, 0f);
                newAssignment.transform.rotation = transform.rotation;
                newAssignment.SetActive(true);
            }
            
            if (power)
            {
                GameObject newPowerUp = powerUpPool.GetPooledObject();
                newPowerUp.transform.position = transform.position + new Vector3(0f, Random.Range(1f, 1f), 0f);
                newPowerUp.SetActive(true);
            }
            /*if (coin & spike)
            {
                theCoinGenerator.spawnCoins(new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z));
                Vector3 spikePosition = new Vector3(spikeXposition, 0.5f, 0f);
                GameObject newSpike = theSpikePool.GetPooledObject();
                newSpike.transform.position = transform.position + spikePosition;
                newSpike.transform.rotation = transform.rotation;
                newSpike.SetActive(true);
            }
            else
            {
                if (coin)
                {
                    theCoinGenerator.spawnCoins(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
                }
                if (spike)
                {
                    Vector3 spikePosition = new Vector3(spikeXposition, 0.5f, 0f);
                    GameObject newSpike = theSpikePool.GetPooledObject();
                    newSpike.transform.position = transform.position + spikePosition;
                    newSpike.transform.rotation = transform.rotation;
                    newSpike.SetActive(true);
			

                }
                //Instantiate (thePlatform, transform.position, transform.rotation);
            }*/
        }
        
    }
}
