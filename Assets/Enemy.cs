 using System;
 using System.Collections;
 using System.Collections.Generic;
 using Unity.VisualScripting;
 using UnityEngine;
 using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;

    private bool hasTarget;
    private Transform target;
    [SerializeField] private Animator animator;
    [SerializeField] private Material _blinkMat;
    [SerializeField] private Material _ogMat;
     private MeshRenderer [] _meshRenderers;

    private void Awake()
    {
        _meshRenderers = GetComponentsInChildren<MeshRenderer>();
    }

    private void SetAgentTarget(Vector3 target)
    {
        navMeshAgent.SetDestination(target);
    }

    private void FixedUpdate()
    {
        if (!hasTarget )
        {
            target = GameObject.FindWithTag("Player").transform;
            SetAgentTarget(target.position);
            animator.SetInteger("Walk", 1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            StartCoroutine(nameof(BlinkForSeconds));
            Debug.Log("enemyHit");
        }
    }
    
    public IEnumerator BlinkForSeconds()
    {
        SwitchMaterial(_blinkMat);
        yield return new WaitForSeconds(.5f);
        SwitchMaterial(_ogMat);
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }

    private void SwitchMaterial(Material mat)
    {
        foreach (var renderer in _meshRenderers)
        {
            renderer.material = mat;
        }
    }
}
 
 