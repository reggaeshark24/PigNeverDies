using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class mainmenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("level_1.1"); 
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
