using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopPricing : MonoBehaviour
{
    float moneyAmount;
    private int gender;
    public Text moneyAmountText;
    public Text joggersPrice;
    private Animator myAnimator = null;
    public RuntimeAnimatorController[] myControllers = null;
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        moneyAmount = PlayerPrefs.GetFloat("Score");
        moneyAmountText.text = moneyAmount.ToString();

        gender = PlayerPrefs.GetInt("Gender");
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Shop")
        {
            if (gender == 0)
            {
                myAnimator.runtimeAnimatorController = myControllers[0];
            }
            else if (gender == 1)
            {
                myAnimator.runtimeAnimatorController = myControllers[4];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        moneyAmountText.text = moneyAmount.ToString();
    }

    public void buyJoggers()
    {
        if (PlayerPrefs.GetInt("Joggers")==1)
        {
            SceneManager.LoadScene("Item Posessed");
        }
        else if (moneyAmount>=200.0f)
        {
            SceneManager.LoadScene("Confirm Purchase Item 1");
        }
        else
        {
            SceneManager.LoadScene("Insufficient Balance");
        }
    }

    public void confirmBuyJoggers()
    {
        moneyAmount -= 200.0f;
        PlayerPrefs.SetFloat("Score", moneyAmount);
        PlayerPrefs.SetInt("Joggers", 1);
        PlayerPrefs.SetInt("Hoodie", 0);
        PlayerPrefs.SetInt("Watch", 0);
        SceneManager.LoadScene("Shop");
    }
    public void joggerSprite()
    {
        if (gender == 0)
        {
            myAnimator.runtimeAnimatorController = myControllers[1];
        }
        else
        {
            myAnimator.runtimeAnimatorController = myControllers[5];
        }
    }

    public void buyWatch()
    {
        if (PlayerPrefs.GetInt("Watch") == 1)
        {
            SceneManager.LoadScene("Item Posessed");
        }
        else if (moneyAmount >= 450.0f)
        {
            SceneManager.LoadScene("Confirm Purchase Item 2");
        }
        else
        {
            SceneManager.LoadScene("Insufficient Balance");
        }
    }

    public void confirmBuyWatch()
    {
        moneyAmount -= 450.0f;
        PlayerPrefs.SetFloat("Score", moneyAmount);
        PlayerPrefs.SetInt("Watch", 1);
        PlayerPrefs.SetInt("Hoodie", 0);
        PlayerPrefs.SetInt("Joggers", 0);
        SceneManager.LoadScene("Shop");
    }
    public void watchSprite()
    {
        if (gender == 0)
        {
            myAnimator.runtimeAnimatorController = myControllers[2];
        }
        else
        {
            myAnimator.runtimeAnimatorController = myControllers[6];
        }
    }

    public void buyHoodie()
    {
        if (PlayerPrefs.GetInt("Hoodie") == 1)
        {
            SceneManager.LoadScene("Item Posessed");
        }
        else if (moneyAmount >= 750.0f)
        {
            SceneManager.LoadScene("Confirm Purchase Item 3");
        }
        else
        {
            SceneManager.LoadScene("Insufficient Balance");
        }
    }

    public void confirmBuyHoodie()
    {
        moneyAmount -= 750.0f;
        PlayerPrefs.SetFloat("Score", moneyAmount);
        PlayerPrefs.SetInt("Hoodie", 1);
        PlayerPrefs.SetInt("Joggers", 0);
        PlayerPrefs.SetInt("Watch", 0);
        SceneManager.LoadScene("Shop");
    }
    public void hoodieSprite()
    {
        if (gender == 0)
        {
            myAnimator.runtimeAnimatorController = myControllers[3];
        }
        else
        {
            myAnimator.runtimeAnimatorController = myControllers[7];
        }
    }
}
