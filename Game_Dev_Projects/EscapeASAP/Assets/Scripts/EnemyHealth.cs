using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int enemyHealth = 100;

    public void DamageEnemy(int damageAmount)
    {
        BroadcastMessage("OnDamageTaken");
        enemyHealth -= damageAmount;
        if (enemyHealth <= 0) { KillEnemy(); }
    }

    void KillEnemy()
    {
        GetComponent<Animator>().SetTrigger("die");
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
    }
}
