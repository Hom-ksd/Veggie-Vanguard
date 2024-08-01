using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerUtility : MonoBehaviour
{
    public static SceneManagerUtility instance;

    private void Awake()
    {
        // Ensure only one instance of SceneManagerUtility exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Preload a scene by its build index
    public void PreloadScene(int sceneID)
    {
        StartCoroutine(PreloadSceneCoroutine(sceneID));
    }

    private IEnumerator PreloadSceneCoroutine(int sceneID)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneID, LoadSceneMode.Additive);
        asyncLoad.allowSceneActivation = false; // Don't activate the scene immediately

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    // Change to a preloaded scene by its build index
    public void ChangeScene(int sceneID)
    {
        StartCoroutine(ChangeSceneCoroutine(sceneID));
    }

    private IEnumerator ChangeSceneCoroutine(int sceneID)
    {
        // Unload the current scene (optional if needed)
        AsyncOperation unloadCurrentScene = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        yield return unloadCurrentScene;

        // Activate the new scene
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneID, LoadSceneMode.Single);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
