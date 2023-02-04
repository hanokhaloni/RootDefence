using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerTurretController : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform aim;
    [SerializeField] private Animator animator;
    [SerializeField] private float timeToWaitBeforeFirstShot;
    [SerializeField] private float timeToWaitBeforeEachShot;

    private GameObject target;
    
    void Start()
    {
   //     InvokeRepeating("Shoot",timeToWaitBeforeFirstShot, timeToWaitBeforeEachShot);
        InvokeRepeating("AnimateShoot",timeToWaitBeforeFirstShot - 1f, timeToWaitBeforeEachShot);
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            target = other.gameObject;
            //    Debug.Log("enemyNear");
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            target = other.gameObject;
        //    Debug.Log("enemyNear");
        }
    }

    private void FixedUpdate()
    {
        if (target!=null)
        {
            transform.LookAt(target.transform);
        }
    }

    void Shoot()
    {
        Instantiate(projectile, aim.position, aim.rotation);
    }

    void AnimateShoot()
    {
        animator.SetTrigger("Shoot");
    }
}
