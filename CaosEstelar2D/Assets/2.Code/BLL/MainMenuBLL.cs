using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBLL : MonoBehaviour
{
    
    public void LoadGameOnClick()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadCreditsOnClick()
    {
        SceneManager.LoadScene("Credits Scene");
    }

    public void LoadMainMenuOnclick()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void ExitGameOnClick()
    {
        Application.Quit();
    }

}
