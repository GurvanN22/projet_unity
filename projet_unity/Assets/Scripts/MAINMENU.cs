using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MAINMENU : MonoBehaviour
{
    public string levelToLoad;
    public GameObject settingsWindow;
    
    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }
    public void SettingsBtn()
    {
        settingsWindow.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
