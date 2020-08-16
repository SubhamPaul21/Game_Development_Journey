using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int enemyHealth = 100;

    public void DamageEnemy(int damageAmount)
    {
        enemyHealth -= damageAmount;
        if (enemyHealth <= 0) { KillEnemy(); }
    }

    void KillEnemy()
    {
        Destroy(gameObject);
    }
}
