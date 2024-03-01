using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MAINMENU : MonoBehaviour
{
    public string levelToLoad;
    
    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }
    public void SettingsBtn()
    {
        
    }
    public void Quit()
    {
        Application.Quit();
    }
}
