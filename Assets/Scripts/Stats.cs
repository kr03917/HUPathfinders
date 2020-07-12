using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Stats : MonoBehaviour
{
    public Text scoreText;
    public Text levelText;
    public float scoreCount;
    public float levelCount;
    public Text assignmentText;
    public float assignmentScore;
    public int playerLevel;
    private string prev;
    public AudioSource source;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    public AudioClip audio;
    // Start is called before the first frame update
    void Start()
    {
        scoreCount = PlayerPrefs.GetFloat("Score");
        levelCount = PlayerPrefs.GetInt("Level");
        assignmentScore = PlayerPrefs.GetFloat("Assignment");
        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        levelText.text = "Levels Completed: " + Mathf.Round(levelCount) + "/4";
        assignmentText.text = "Documents: " + Mathf.Round(assignmentScore) + "/5";
        source = GetComponent<AudioSource>();
        audio = source.clip;
        AudioSource.PlayClipAtPoint(audio, this.gameObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void retake()
    {
        prev = PlayerPrefs.GetString("PreviousLevel");
        SceneManager.LoadScene(prev);
    }
}
