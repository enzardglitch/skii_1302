using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject menuGroup;

    private GameObject currentMenu;

    public void Start()
    {
        AudioManager.instance.PlayBGM(0);
        currentMenu = menuGroup.transform.Find("Home").gameObject;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Loading");

    }

    public void Exit()
    {
        Application.Quit();
    }

    public void SwitchMenu(string menuName)
    {
        if (currentMenu != null)
        {
            currentMenu.SetActive(false);
        }
        Transform newMenu = menuGroup.transform.Find(menuName);
        if (newMenu != null) 
        {
            currentMenu = newMenu.gameObject;
            currentMenu.SetActive(true);
        }
    }

    public void ResetLevel()
    {
        PlayerPrefs.SetInt("gameLevel", 0);
        PlayerPrefs.SetInt("gameCoins", 0);
    }

}
