
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string MainMenu;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    public object DontDestroyOnLoadScene { get; private set; }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resumed();
            }
            else
            {
                Paused();
            }
        }
    }

    public void Paused()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Resumed()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void mainMenu()
    {
        SceneManager.LoadScene(MainMenu);
    }
    
}
