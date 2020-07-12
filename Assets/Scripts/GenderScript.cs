using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GenderScript : MonoBehaviour
{
    public Button male;
    public Button female;
    // Start is called before the first frame update
    public void maleSelected()
    {
        PlayerPrefs.SetInt("Gender", 0);
        SceneManager.LoadScene("Main Menu");
    }

    public void femaleSelected()
    {
        PlayerPrefs.SetInt("Gender", 1);
        SceneManager.LoadScene("Main Menu");
    }

}
