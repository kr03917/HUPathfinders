using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    private TimerTool theTimerTool;
    private ScoreManager theScoreManager;
    private PlatformGenerator thePlatformGenerator;
    private PlayerController thePlayerController;
    private GameManager theGameManager;
    private int powerUp;
    private bool powerUpActive;
    private float powerUpLength;
    private float playerSpeed;
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
        thePlatformGenerator = FindObjectOfType<PlatformGenerator>();
        theTimerTool = FindObjectOfType<TimerTool>();
        thePlayerController = FindObjectOfType<PlayerController>();
        theGameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (powerUpActive)
        {
            powerUpLength -= Time.deltaTime;

            if (powerUpLength <= 0)
            {
                thePlayerController.moveSpeed = playerSpeed;
                thePlayerController.collisionHold = true;
                powerUpActive = false;
                SpriteRenderer myRenderer = thePlayerController.GetComponent<SpriteRenderer>();
                Color newColor = myRenderer.color;
                newColor.a = 1f;
                myRenderer.color = newColor;
            }
        }
        
    }
    public void ActivatePowerUp(int power, float seconds)
    {
        powerUp = power;
        playerSpeed = thePlayerController.moveSpeed;
        powerUpLength = seconds;

        //normal = theScoreManager.pointsPerSeconds;
        switch (powerUp)
        {
            case 0:
                theTimerTool.time += 5;
                powerUpActive = false;
                break;

            case 1:
                SpriteRenderer myRenderer = thePlayerController.GetComponent<SpriteRenderer>();
                Color newColor = myRenderer.color;
                newColor.a = 0.3f;
                myRenderer.color = newColor;
                powerUpActive = true;
                thePlayerController.collisionHold = false;
                break;

            case 2:
                if (thePlayerController.moveSpeed < thePlayerController.maxSpeed)
                {
                    thePlayerController.moveSpeed += 3;
                }
                    thePlayerController.collisionHold = false;
                    powerUpActive = false;
                
                break;

            case 3:
                thePlatformGenerator.randomSpikeThreshold = 0;
                powerUpActive = false;
                break;

            case 4:
                break;

            //Obstacles
            case 5:
                if (thePlayerController.collisionHold)
                {
                    thePlayerController.fallen = true;
                    thePlayerController.moveSpeed = 0;
                    powerUpActive = true;
                }
                break;

            case 6:
                if (thePlayerController.collisionHold)
                {
                    thePlayerController.fallen = true;
                    thePlayerController.moveSpeed = 0;
                    powerUpActive = true;
                }
                break;

            case 7:
                theGameManager.GameOver();
                break;

        }
        //spikeRate = thePlatformGenerator.randomSpikeThreshold;
    }
}
