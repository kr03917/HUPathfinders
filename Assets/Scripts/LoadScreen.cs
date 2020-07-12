using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScreen : MonoBehaviour
{
    public string levelToLoad;

    public GameObject loadingScreen;

    public Slider loadingBar;

    public Text loadingText;



    //GameplayController.GetComponent<ButtonHandler>().OnMouseClick();

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            loadingScreen.SetActive(true);
            //SceneManager.LoadScene(levelToLoad);
            StartCoroutine(LoadLevelAsync());
        }
        
    }

    private IEnumerator LoadLevelAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelToLoad);

        asyncLoad.allowSceneActivation = false;

        while(!asyncLoad.isDone)
        {
            loadingBar.value = asyncLoad.progress;

            if (asyncLoad.progress >= .9f && !asyncLoad.allowSceneActivation)
            {
                asyncLoad.allowSceneActivation = true;

            }

            yield return null;
        }
    }
}
//if (ButtonHandler.OnMouseClick()= true)