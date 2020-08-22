using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int pickupAmmoAmount = 3;
    [SerializeField] AmmoType ammoType;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<Ammo>().AddAmmoOnPickup(ammoType, pickupAmmoAmount);
            Destroy(gameObject);
        }    
    }
}
