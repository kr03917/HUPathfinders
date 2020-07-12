using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    private float powerUpLength = 3f;
    public Sprite[] powerUpSprites;
    int powerUpSelector;
    private PowerUpManager thePowerUpManager;
    public float powerUpH;
    private GameManager theGameManager;
    public int levelData;
    
    void Start()
    {
        thePowerUpManager = FindObjectOfType<PowerUpManager>();
        theGameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Awake()
    {
        //int levelData = ButtonHandler.GetDifferentiatingVariable();
        //Debug.Log(levelData);
        if (levelData == 1)
        {
            var myCodes = new int[2];
            myCodes[0] = 0;
            myCodes[1] = 5;
            var index = Random.Range(0, myCodes.Length);
            powerUpSelector = myCodes[index];
        }
        else
        {
            powerUpSelector = Random.Range(0, 7);
        }
        GetComponent<SpriteRenderer>().sprite = powerUpSprites[powerUpSelector];
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Custom Sprite")
        {
            thePowerUpManager.ActivatePowerUp(powerUpSelector, powerUpLength);
        }
        gameObject.SetActive(false);
    }
}
