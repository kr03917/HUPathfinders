using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonActive : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public int playerLevel;
    // Start is called before the first frame update
    void Awake()
    {
        playerLevel = PlayerPrefs.GetInt("Level");
        button1.interactable = true;
        if (playerLevel==1)
        {
            button2.interactable = true;
        }
        else if (playerLevel==2)
        {
            button2.interactable = true;
            button3.interactable = true;
        }
        else if ((playerLevel==3) || (playerLevel==4))
        {
            button2.interactable = true;
            button3.interactable = true;
            button4.interactable = true;
        }
    }
}
