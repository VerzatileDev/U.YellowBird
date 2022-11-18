using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuUI;
    [SerializeField] private GameObject settingsMenuUI;

    public void StartButton()
    {
        //Debug.Log("Starting New game");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        //Debug.Log("Quitting Game");
        Application.Quit();
    }

    public void Back()
    {
        MainMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
    }

    public void Settings()
    {
        MainMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
    }
}
