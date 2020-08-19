using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPSCamera;
    [SerializeField] float maxRange = 100f;
    [SerializeField] int weaponDamage = 10;
    [SerializeField] ParticleSystem muzzleFlashVFX;
    [SerializeField] GameObject hitEffectVFX;

    Ammo ammoSlot;
    private void Start() 
    {
        ammoSlot = GetComponent<Ammo>();
    }
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
        if (ammoSlot.GetCurrentAmmo() > 0)
        {
            ammoSlot.ReduceAmmoOnShoot();
            EmitMuzzleFlashVFX();
            ProcessRayCast();
        }
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
            CreateHitEffect(hit);
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

    void CreateHitEffect(RaycastHit hit)
    {
        GameObject hitEffect = Instantiate(hitEffectVFX,
                                        hit.point,
                                        Quaternion.LookRotation(hit.normal)) as GameObject;

        Destroy(hitEffect, 0.1f);
    }
}
