using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene"); 
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); 
    }
}