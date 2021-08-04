using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public GameObject loader;
    public Slider loadingBar;
    public Text loadText;
    public string scene;

    public void LoadButton()
    {
        if (scene != "")
        {
            loader.SetActive(true);
            StartCoroutine(LoadScene(scene));
        }
    }

    IEnumerator LoadScene(string sceneName)
    {
        yield return null;

        
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;
        

        while (!asyncOperation.isDone)
        {
            loadingBar.value = asyncOperation.progress;
            loadText.text = asyncOperation.progress * 100 + "%";

            if (asyncOperation.progress >= 0.9f)
            {
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
