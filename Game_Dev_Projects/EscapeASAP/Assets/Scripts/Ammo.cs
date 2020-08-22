using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    int ammoAmount = 10;
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }


    // Method to return the number of ammo's left
    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }
    
    // Method to reduce the ammo on shooting
    public void ReduceAmmoOnShoot(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount--;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach(AmmoSlot slot in ammoSlots)
        {
            if(slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }

    // Method to add ammo on pick up
    public void AddAmmoOnPickup(AmmoType ammoType, int ammoAmount)
    {
        GetAmmoSlot(ammoType).ammoAmount += ammoAmount;
    }
}
