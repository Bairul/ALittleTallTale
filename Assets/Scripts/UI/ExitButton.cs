using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void QuitAppication()
    {
        Debug.Log("Application Quit");
        Application.Quit();
    }
}
