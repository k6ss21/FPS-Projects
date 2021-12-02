using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject gameEndUI;

    public void ReloadLevel()
    {
        int curr_scene = SceneManager.GetActiveScene().buildIndex;
         Debug.Log("scne Index : " + curr_scene);
        SceneManager.LoadScene(curr_scene);
        
       // gameEndUI.SetActive(false);
    }
    public void Mainmenu()
    {
        Debug.Log(" Load Main Menu");
    }
}
