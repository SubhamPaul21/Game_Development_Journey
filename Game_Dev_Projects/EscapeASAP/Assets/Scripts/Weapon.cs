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
    [SerializeField] AmmoType ammoType;
    [SerializeField] float shootDelay = 2f;
    Ammo ammoSlot;
    bool canShoot = true;

    private void OnEnable() 
    {
        canShoot = true;
    }

    private void Start() 
    {
        ammoSlot = FindObjectOfType<Ammo>();
    }
    void Update()
    {
        
        ProcessUserInput();
    }

    void ProcessUserInput()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            ammoSlot.ReduceAmmoOnShoot(ammoType);
            EmitMuzzleFlashVFX();
            ProcessRayCast();
        }
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
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
