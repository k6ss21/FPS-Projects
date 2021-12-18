using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
   

    public void ReloadLevel()
    {
        int curr_scene = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1;
        SceneManager.LoadScene(curr_scene);

       // gameEndUI.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
}
