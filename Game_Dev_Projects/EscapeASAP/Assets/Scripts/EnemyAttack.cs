using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] int attackDamage = 30;
    PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if (playerHealth == null) { return; }
        playerHealth.DamagePlayer(attackDamage);
    }
}
