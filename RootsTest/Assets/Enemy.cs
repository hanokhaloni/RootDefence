using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
   [SerializeField] private NavMeshAgent navMeshAgent;

   private bool hasTarget;
   
   public void SetAgentTarget(Transform target)
   {
      navMeshAgent.SetDestination(target.position);
   }
   
   
   
}
