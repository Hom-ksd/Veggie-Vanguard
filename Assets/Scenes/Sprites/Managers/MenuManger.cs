using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManger : MonoBehaviour
{
    [SerializeField]
    private PauseManager m_PauseManager;

    [SerializeField]
    private Button pauseButton;

    [SerializeField]
    private GameStateManager m_GameStateManager;

    [SerializeField]
    private CountdownTimer m_countdownTimer;

    [SerializeField]
    private GameObject winningMenu;

    [SerializeField]
    private ShopManager m_shopManager;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !m_GameStateManager.IsGameOver() && m_countdownTimer.IsTimeRemaining())
        {
            if (m_PauseManager.IsPaused())
                m_PauseManager.ResumeGame();
            else
                m_PauseManager.PauseGame();
        }
        if (m_GameStateManager.IsGameOver())
        {
            pauseButton.enabled = false;
        }

        if (!m_countdownTimer.IsTimeRemaining())
        {
            pauseButton.enabled = false;
            winningMenu.SetActive(true);
            Time.timeScale = 0f;
        }

        if (!m_GameStateManager.IsBuying())
        {
            for (int i = 0; i < 6; i++)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1 + i))
                {
                    if(m_shopManager.CheckInputForPlant(KeyCode.Alpha1 + i, i))
                    {
                        m_GameStateManager.SetBuying(true);
                    }
                    else
                    {
                        m_GameStateManager.SetBuying(false);
                    }
                }
            }
        }
    }
}
