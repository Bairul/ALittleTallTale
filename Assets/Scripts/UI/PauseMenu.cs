using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private float pauseCooldown = 0.5f;
    private float nextPauseAllowedTime = 0f;
    private bool isPaused = false;
    private bool allowPausing = true;

    public void ToggleAllowPausing(bool toggle)
    {
        allowPausing = toggle;
        gameObject.SetActive(toggle);
    }

    private bool CanPause()
    {
        return allowPausing && Time.unscaledTime >= nextPauseAllowedTime;
    }

    void Update()
    {
        if (!CanPause()) return;

        if (Input.GetKeyDown(KeyCode.Escape)) TogglePause();
    }

    public void TogglePause()
    {
        if (!CanPause()) return;

        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
            nextPauseAllowedTime = Time.unscaledTime + pauseCooldown;
        }
        pausePanel.SetActive(isPaused);
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
