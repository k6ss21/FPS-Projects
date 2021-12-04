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

   public void AfterDeath()
   {
       endGameUI.enabled =true;
       Time.timeScale =0;
       Cursor.lockState = CursorLockMode.None;
       Cursor.visible = true;
   }
}
