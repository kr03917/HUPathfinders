using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerTool : MonoBehaviour
{
    public CountDownController theCountDown;
    string levelToLoad = "Game Over";
    Image fillImg;
    float timeAmount = 50;
    public float time = 100;
    public Text timeText;
    bool start2;
    // Start is called before the first frame update
    void Start()
    {
        fillImg = this.GetComponent<Image>();
        time = timeAmount;
        theCountDown = FindObjectOfType<CountDownController>();
    }

    // Update is called once per frame
    void Update()
    {
        start2 = theCountDown.start;
        if (start2)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                fillImg.fillAmount = time / timeAmount;
                timeText.text = "0:" + time.ToString("0");
            }
            else
            {
                SceneManager.LoadScene(levelToLoad);
            }
        }
    }
}
