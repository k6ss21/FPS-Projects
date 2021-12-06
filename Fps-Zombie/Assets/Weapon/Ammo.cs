using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public Ammotype ammotype;
        public int ammoAmount;
    }

    public int GetCurrentAmmo(Ammotype ammotype)
    {
        return GetAmmoSlot(ammotype).ammoAmount;
    }
    public void reduceCurrentAmmo(Ammotype ammotype)
    {
       GetAmmoSlot(ammotype).ammoAmount--;

    }

     public void IncreaseCurrentAmmo(Ammotype ammotype, int amount)
    {
       GetAmmoSlot(ammotype).ammoAmount += amount;

    }

   

    private AmmoSlot GetAmmoSlot(Ammotype ammotype)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.ammotype == ammotype)
            {
                return slot;
            }
        }
        return null;
    }
}
