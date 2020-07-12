using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class RO : MonoBehaviour
{
    public GameObject docPrompt;
    public ScoreManager theScoreManager;
    public Stats theStats;
    public GameManager theGameManager;
    // Start is called before the first frame update
    void Start()
    {
        docPrompt.SetActive(false);
        theScoreManager = FindObjectOfType<ScoreManager>();
        theGameManager = FindObjectOfType<GameManager>();
        theStats = FindObjectOfType<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void disableText()
    {
        docPrompt.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (theScoreManager.assignmentScore >= 5)
            {
                if (SceneManager.GetActiveScene().name=="Level2")
                {
                    PlayerPrefs.SetInt("Level", 2);
                }
                else if ((SceneManager.GetActiveScene().name == "Level4"))
                {
                    PlayerPrefs.SetInt("Level", 4);
                }
                
                PlayerPrefs.Save();
                theGameManager.GameOver();
            }
            else
            {
                docPrompt.SetActive(true);
                Text changingText = GameObject.Find("Canvas/Text").GetComponent<Text>();
                int docRemaining = 5 - theScoreManager.assignmentScore;
                changingText.text = "Documents remaining: " + docRemaining.ToString() + "\n keep searching!";
                Invoke("disableText", 2);
            }
        }
    }
}
