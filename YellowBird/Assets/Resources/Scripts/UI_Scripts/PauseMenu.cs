using UnityEngine;

/// <summary>
///
/// License:
/// Copyrighted to Brian "VerzatileDev" Lätt ©2024.
/// Do not copy, modify, or redistribute this code without prior consent.
/// All rights reserved.
///
/// </summary>
/// <remarks>
/// Hosts Buttons and Functions for the Pause Menu such as Resume, Quit, and Retry.
/// Additionally checks if the player is dead and if so, pauses the game and displays the End Game Menu.
/// </remarks>
public class PauseMenu : MonoBehaviour
{
    protected internal static bool gamePaused = false;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject endGameMenuUI;
    private bool isDead = false;

    void Update()
    {
        isDead = PlayerMovement.isKilled;
        if (Input.GetKeyDown(KeyCode.Escape) && isDead != true)
        {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (isDead == true)
            DeathPause();
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }
    
    public void Quit()
    {
        Application.Quit();
    }

    public void DeathPause()
    {
        endGameMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ReTry()
    {
        endGameMenuUI.SetActive(false);
        PlayerMovement.isKilled = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }

    public void BackToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}