using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour {
    
    public void OpenControlsLevel()
    {
        SceneManager.LoadScene((int)ApplicationLevel.Controls);
    }

    public void StartGame()
    {
        SceneManager.LoadScene((int)ApplicationLevel.Game);
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene((int)ApplicationLevel.MainMenu);
    }
}
