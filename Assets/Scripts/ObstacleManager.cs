using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    private TimerTool theTimerTool;
    private ScoreManager theScoreManager;
    private PlatformGenerator thePlatformGenerator;
    private PlayerController thePlayerController;
    private int obstacle;
    private bool obstacleActive;
    private float obstacleLength;
    private float playerSpeed;
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
        thePlatformGenerator = FindObjectOfType<PlatformGenerator>();
        theTimerTool = FindObjectOfType<TimerTool>();
        thePlayerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (obstacleActive)
        {
            obstacleLength -= Time.deltaTime;
            if (obstacleLength <= 0)
            {
                thePlayerController.moveSpeed = playerSpeed;
            }
        }
    }

    public void ActivateObstacle(int obs, float seconds)
    {
        obstacle = obs;
        obstacleLength = seconds;
        playerSpeed = thePlayerController.moveSpeed;
        switch (obstacle)
        {
            case 0:
                Debug.Log(obstacle);
                thePlayerController.moveSpeed = 0;
                obstacleActive = true;
                break;
        }
    }
}