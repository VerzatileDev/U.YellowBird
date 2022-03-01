using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject settingsMenuUI;
    public static bool InsideSettings = false;

    public void StartButton()
    {
        //MainMenuUI.SetActive(false); // No idea why this is here.
        Debug.Log("Starting New game");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        Time.timeScale = 1f; // Freeze Game
    }

    public void Quit()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

    public void Back()
    {
        MainMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
        InsideSettings = false;
    }

    public void Settings()
    {
        MainMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
        InsideSettings = true;
    }
}
