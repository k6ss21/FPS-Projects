using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas bloodCanvas;
    [SerializeField] float bloodTime = .3f;
    void Start()
    {
        bloodCanvas.enabled = false;
    }

    
    public void DisplayBlood()
    {
        StartCoroutine(ShowBlood());
    }

    IEnumerator ShowBlood()
    {
        bloodCanvas.enabled = true;
        yield return new WaitForSeconds(bloodTime);
        bloodCanvas.enabled = false;
    }
}
