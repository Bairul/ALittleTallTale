using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void QuitAppication()
    {
        Debug.Log("Application Quit");
        Application.Quit();
    }

    public void StartGameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
