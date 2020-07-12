using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
	public GameObject docCollect;
    public CSOAnimator Cso;
	public bool docCheck = false;
    string levelToLoad = "GameOver";
    public ScoreManager theScoreManager;
    public GameObject health1, health2, health3;
    public static int health;
    string dest = "";
    string dest2 = "";
    public bool collideCSO = false;
    
    public void Start()
    {
        Cso = FindObjectOfType<CSOAnimator>();
        health = 3;
        health1.gameObject.SetActive(true);
        health2.gameObject.SetActive(true);
        health3.gameObject.SetActive(true);
    }

    public void Update()
    {
        if (health > 3)
            health = 3;

        switch(health)
        {
            case 3:
                health1.gameObject.SetActive(true);
                health2.gameObject.SetActive(true);
                health3.gameObject.SetActive(true);
                break;

            case 2:
                health1.gameObject.SetActive(true);
                health2.gameObject.SetActive(true);
                health3.gameObject.SetActive(false);
                break;

            case 1:
                health1.gameObject.SetActive(true);
                health2.gameObject.SetActive(false);
                health3.gameObject.SetActive(false);
                break;

            case 0:
                health1.gameObject.SetActive(false);
                health2.gameObject.SetActive(false);
                health3.gameObject.SetActive(false);
                GameOver();
                break;
        }
	checkAssignment();
    }
    public void GameOver()
    {
        PlayerPrefs.SetFloat("Score", theScoreManager.scoreCount);
        PlayerPrefs.SetFloat("High", theScoreManager.highScoreCount);
        PlayerPrefs.SetFloat("Assignment", theScoreManager.assignmentScore);
        PlayerPrefs.SetString("PreviousLevel", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();
        StartCoroutine("GameOverCo");
    }

	private void disableText(){
		docCollect.SetActive(false);
	}
    public void checkAssignment()
    {
	    if (docCheck==false && theScoreManager.assignmentScore == 5)
        {
		    docCheck = true;
		    docCollect.SetActive(true);
		    Text changingText = GameObject.Find("Canvas/Text").GetComponent<Text>();
            dest = SceneManager.GetActiveScene().name;
            if (dest == "Level1")
            {
                dest2 = "Admissions";
            }
            else if ((dest == "Level2") || (dest=="Level4"))
            {
                dest2 = "RO";
            }
            else if (dest == "Level3")
            {
                dest2 = "OAP";
            }
            changingText.text = "Find the path to the "+ dest2;
		    Invoke("disableText",2);
	    }
	}
    public IEnumerator GameOverCo()
    {
        if (theScoreManager.assignmentScore >= 5 & health>=1 & collideCSO==false)
        {
            levelToLoad = "Game Success";
        }
        else
        {
            levelToLoad = "GameOver";
        }
        SceneManager.LoadScene(levelToLoad);
        yield return new WaitForSeconds(0.5f);
    }
}
