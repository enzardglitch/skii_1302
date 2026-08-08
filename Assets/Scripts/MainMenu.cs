using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //dimala'sh ludii el isnihd 

    public void StartGame()
    {
        SceneManager.LoadScene("Scene01");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
