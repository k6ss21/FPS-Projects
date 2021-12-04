using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 10f;
    [SerializeField] float turnSpeed = 5f;
    NavMeshAgent navMeshAgent;
    Animator _Animator;

    float distanceToTarget = Mathf.Infinity;

    bool isProvoked = false;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        _Animator = GetComponent<Animator>();
    }


    void Update()
    {
        AttackPlayer();
    }

    void AttackPlayer()
    {
        FaceTarget();
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
        
    }

    private void EngageTarget()
    {
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
        else if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
             _Animator.SetBool("Attack",false);
            ChaseTarget();
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    void ChaseTarget()
    {
        _Animator.SetTrigger("Move");
        navMeshAgent.SetDestination(target.position);
    }

    void AttackTarget()
    {
        _Animator.SetBool("Attack",true);
        //Debug.Log(name + "is Destroying" + target.name);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z) );
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime * turnSpeed);
    }

    

}
