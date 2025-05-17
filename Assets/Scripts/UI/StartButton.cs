using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void StartGameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
