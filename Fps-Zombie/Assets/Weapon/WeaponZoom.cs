using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;

    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;

    [SerializeField] float zoomedInSens = 1f;
    [SerializeField] float zoomedOutSens = 2f;

    [SerializeField] RigidbodyFirstPersonController fpsController;

    bool zoomInToggle = false;

    
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (zoomInToggle == false)
            {
                zoomInToggle = true;
                fpsCamera.fieldOfView = zoomedInFOV;
                fpsController.mouseLook.XSensitivity = zoomedInSens;
                fpsController.mouseLook.YSensitivity = zoomedInSens;
            }
            else if (zoomInToggle == true)
            {
                zoomInToggle = false;
                fpsCamera.fieldOfView = zoomedOutFOV;
                fpsController.mouseLook.XSensitivity = zoomedOutSens;
                fpsController.mouseLook.YSensitivity = zoomedOutSens;

            }
        }

    }
}
