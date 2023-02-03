using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;

    private bool hasTarget;
    private Transform target;
    [SerializeField] private float stoppingDistanceOffset;
    [SerializeField] private Animator animator;

    public void SetAgentTarget(Vector3 target)
    {
        navMeshAgent.SetDestination(target);
    }

    private void FixedUpdate()
    {

        if (!hasTarget )
        {
            target = GameObject.FindWithTag("Player").transform;
            SetAgentTarget(target.position);
            hasTarget = true;
            animator.SetInteger("Walk", 1);
        }

        // else if (Vector3.Distance(navMeshAgent.transform.position, target.transform.position) > stoppingDistanceOffset)
        // {
        //     hasTarget = false;
        // }
    
    }

    private void OnTriggerEnter(Collider other)
    {
        hasTarget = false;
        Debug.Log("hit enemy");
    }
}