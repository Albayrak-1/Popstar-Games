using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        SceneManager.LoadScene("MainScene"); 
    }

    public void GoToMainMenu()
    {
        Cursor.lockState = CursorLockMode.None; 
        SceneManager.LoadScene("MainMenu"); 
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }
}