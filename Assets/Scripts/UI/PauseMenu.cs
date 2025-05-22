using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    public float pauseCooldown = 0.5f;
    private float nextPauseAllowedTime = 0f;
    private bool isPaused = false;

    void Update()
    {
        if (Time.unscaledTime < nextPauseAllowedTime)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) Resume();
            else Pause();

            nextPauseAllowedTime = Time.unscaledTime + pauseCooldown;
            Debug.Log(nextPauseAllowedTime);
        }
    }

    public void Pause()
    {
        if (Time.unscaledTime < nextPauseAllowedTime)
            return;

        isPaused = !isPaused;
        if (isPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
