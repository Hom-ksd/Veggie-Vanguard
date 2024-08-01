using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu; // Reference to the pause menu UI

    [SerializeField]
    private bool isPaused = false;

    public void PauseGame()
    {
        Time.timeScale = 0f; // Stop the game time
        pauseMenu.SetActive(true); // Show the pause menu
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game time
        pauseMenu.SetActive(false); // Hide the pause menu
        isPaused = false;
    }

    public bool IsPaused()
    {
        return isPaused;
    }
}
