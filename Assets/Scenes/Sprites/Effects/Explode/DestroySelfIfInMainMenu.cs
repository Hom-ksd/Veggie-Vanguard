using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroySelfIfInMainMenu : MonoBehaviour
{
    [SerializeField]
    private string mainMenuSceneName = "MainMenu"; // Set this to your main menu scene name

    private void Start()
    {
        // Check if the current scene is the main menu
        if (SceneManager.GetActiveScene().name == mainMenuSceneName)
        {
            Destroy(gameObject); // Destroy this GameObject if we're in the main menu scene
        }
    }
}
