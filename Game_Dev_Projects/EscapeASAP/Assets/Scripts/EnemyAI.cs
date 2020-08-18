using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;
    NavMeshAgent navMeshAgent;
    Animator animator;
    bool isProvoked = false;
    float distanceFromTarget = Mathf.Infinity;  

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        ProcessEnemyBehaviour();
    }

    void ProcessEnemyBehaviour()
    {
        distanceFromTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceFromTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }

    private void EngageTarget()
    {
        FaceTarget();
        if (distanceFromTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (distanceFromTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    void AttackTarget()
    {
        animator.SetBool("attack", true);
    }

    void ChaseTarget()
    {
        animator.SetTrigger("move");
        animator.SetBool("attack", false);
        navMeshAgent.SetDestination(target.position);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0 , direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, turnSpeed);
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
