using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //dimala'sh ludii el isnihd 

    public void StartGame()
    {
        SceneManager.LoadScene("Loading");

    }

    public void Exit()
    {
        Application.Quit();
    }
}
