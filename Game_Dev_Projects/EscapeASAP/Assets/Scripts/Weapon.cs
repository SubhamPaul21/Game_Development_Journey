using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPSCamera;
    [SerializeField] float maxRange = 100f;
    [SerializeField] int weaponDamage = 10;
    [SerializeField] ParticleSystem muzzleFlashVFX;
    void Update()
    {
        ProcessUserInput();
    }

    void ProcessUserInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        EmitMuzzleFlashVFX();
        ProcessRayCast();
    }

    void EmitMuzzleFlashVFX()
    {
        muzzleFlashVFX.Play();
    }

    void ProcessRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit, maxRange))
        {
            EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();
            // If EnemyHealth component found
            if (enemyHealth != null)
            {
                enemyHealth.DamageEnemy(weaponDamage);
            }
            // return nothing if EnemyHealth component not found
            else {return;}
        }
    }
}
