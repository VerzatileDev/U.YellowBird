using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    protected internal static bool GameIsPaused = false;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject DiedMenuUI;
    private bool isdead = false;

    void Update()
    {
        isdead = movement.iskilled;
        if (Input.GetKeyDown(KeyCode.Escape) && isdead != true)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (isdead == true)
            DeathPause();
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    
    public void Quit()
    {
        Application.Quit();
    }

    public void DeathPause()
    {
        DiedMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ReTry()
    {
        DiedMenuUI.SetActive(false);
        movement.iskilled = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }

    public void BackToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}