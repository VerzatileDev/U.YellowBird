using UnityEngine;

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
    }
}