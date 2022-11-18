using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    protected internal static bool GameIsPaused = false;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject settingsMenuUI;
    [SerializeField] private GameObject DiedMenuUI;
    private static bool InsideSettings = false;
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
        if (InsideSettings == false)
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void loadSettings()
    {
        //Debug.Log("Loading Settings");
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
        InsideSettings = true;

    }
    public void Quit()
    {
        //Debug.Log("Quitting Game");
        Application.Quit();
    }

    public void Back()
    {
        pauseMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
        InsideSettings = false;
    }

    public void DeathPause()
    {
        DiedMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ReTry()
    {
        DiedMenuUI.SetActive(false);
        //Debug.Log("Retried");
        movement.iskilled = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }

    public void BackToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}