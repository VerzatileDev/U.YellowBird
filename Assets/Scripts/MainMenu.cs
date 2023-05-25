using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
