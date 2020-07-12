using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScreenBeg : MonoBehaviour
{
    //*code inspired by gamesplusjames tutorial*

    public string levelToLoad;

    public GameObject loadingScreen;

    public Slider loadingBar;

    public Text loadingText;

    // Start is called before the first frame update
    void Start()
    {
        loadingScreen.SetActive(true);
        //SceneManager.LoadScene(levelToLoad);
        StartCoroutine(LoadLevelAsync());

    }

    // Update is called once per frame
    void Update()
    {


    }

    private IEnumerator LoadLevelAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelToLoad);

        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
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
