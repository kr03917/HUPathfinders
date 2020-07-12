using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{

    public void GoToMainMenuScene()
    {
        SceneManager.LoadScene("Main Menu");
    }
    
    public void GoToMissionsScene()
    {
        SceneManager.LoadScene("Missions");
    }

    public void GoToOptionsScene()
    {
        SceneManager.LoadScene("Options");
    }

    public void GoToShopScene()
    {
        SceneManager.LoadScene("Shop");
    }

    public void GoToLevel()
    {
        SceneManager.LoadScene("Level1");
    }

    public void GoToLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void GoToLevel3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void GoToLevel4()
    {
        SceneManager.LoadScene("Level4");
    }
    public void GoToObjectives()
    {
        SceneManager.LoadScene("Objectives");
    }

    public void GoToObjectives2()
    {
        SceneManager.LoadScene("Objectives2");
    }
    public void GoToObjectives3()
    {
        SceneManager.LoadScene("Objectives3");
    }
    public void GoToObjectives4()
    {
        SceneManager.LoadScene("Objectives4");
    }
    public void GoToHelp()
    {
        SceneManager.LoadScene("Help1");
    }

    public void GoToHelp2()
    {
        SceneManager.LoadScene("Help2");
    }
    public void GoToHelp3()
    {
        SceneManager.LoadScene("Help3");
    }
    public void GoToHelp4()
    {
        SceneManager.LoadScene("Help4");
    }
    public void GoToLoadingScene()
    {
        SceneManager.LoadScene("LoadingScreen");
    }

    public void GoToPurchase1()
    {

        SceneManager.LoadScene("Confirm Purchase Item 1");
    }

    public void GoToPurchase2()
    {
        SceneManager.LoadScene("Confirm Purchase Item 2");
    }

    public void GoToPurchase3()
    {
        SceneManager.LoadScene("Confirm Purchase Item 3");
    }

    public void GoToGenderScr()
    {
        SceneManager.LoadScene("SelectGender");
    }
    
    public void Exit()
    {
        Application.Quit();
    }



}
