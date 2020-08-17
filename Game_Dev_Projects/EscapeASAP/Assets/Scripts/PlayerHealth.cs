using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth = 100;
    
    public void DamagePlayer(int damageAmount)
    {
        playerHealth -= damageAmount;
        if (playerHealth <= 0)
        {
            print("you are dead man!!!!");
        }
    } 
}
