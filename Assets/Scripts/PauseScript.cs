using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GamePaused = false;
    public GameObject pauseMenuUI;
    public GameObject pauseButton;
    public Text riddle;
    public string activeScene;
    // Update is called once per frame
    public void Start()
    {
        activeScene = SceneManager.GetActiveScene().name;
        if (activeScene=="Level1")
        {
            riddle.text = "Your first riddle is hidden in a place which rhymes with a currency";
        }
        else if (activeScene=="Level2")
        {
            riddle.text = "Where you run but remain at the same place";
        }
        else if (activeScene=="Level3")
        {
            riddle.text = "Next to go and find treasures by ourselves, where stories fill the shelves!";
        }
        else if (activeScene=="Level4")
        {
            riddle.text = "Where you can watch someone shoot and cheer them on";
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
        pauseButton.SetActive(false);
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
        pauseButton.SetActive(true);

    }
    public void loadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
        Debug.Log("Loading");
    }
    public void quitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
