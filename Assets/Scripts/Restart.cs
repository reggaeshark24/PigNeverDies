using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("MainMenu"); 
    }

}
