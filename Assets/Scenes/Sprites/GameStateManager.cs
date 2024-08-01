using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameoverMenu;

    [SerializeField]
    private bool gameover = false;

    [SerializeField]
    private HealthSystem hutHealthSystem;

    [SerializeField]
    private bool isBuying = false;

    private void Update()
    {
        if (hutHealthSystem.getHealthPoint() <= 0 && !gameover)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameover = true;
        Time.timeScale = 0f; // Stop the game time
        gameoverMenu.SetActive(true); // Show the pause menu
    }

    public void MainMenu()
    {
        //load to mainmenu scene
    }

    public bool IsGameOver()
    {
        return gameover;
    }

    public bool IsBuying()
    {
        return isBuying;
    }

    public void SetBuying(bool status)
    {
        isBuying = status;
    }
}
