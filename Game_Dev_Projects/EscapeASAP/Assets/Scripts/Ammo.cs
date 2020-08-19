using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 10;

    // Method to return the number of ammo's left
    public int GetCurrentAmmo()
    {
        return ammoAmount;
    }

    public void ReduceAmmoOnShoot()
    {
        ammoAmount--;
    }
}
