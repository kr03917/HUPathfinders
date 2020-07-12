using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public int level;
    public Text scoreText;
    public float scoreCount;
    public float highScoreCount;
    public Text assignmentText;
    public int assignmentScore;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            scoreCount = PlayerPrefs.GetFloat("Score");
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = scoreCount.ToString();
        assignmentText.text = assignmentScore.ToString();
    }

    public void AddScore(int pointsToAdd)
    {
        scoreCount += pointsToAdd;
    }
}
