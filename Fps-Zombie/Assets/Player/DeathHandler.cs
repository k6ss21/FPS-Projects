using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas endGameUI;
    void Start()
    {
        
        endGameUI.enabled = false;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            
            endGameUI.enabled = !endGameUI.enabled;
            
        }
    }

   public void AfterDeath()
   {
       endGameUI.enabled =true;
       Time.timeScale =0;
       FindObjectOfType<WeaponSwitcher>().enabled = false;
       Cursor.lockState = CursorLockMode.None;
       Cursor.visible = true;
   }
}
