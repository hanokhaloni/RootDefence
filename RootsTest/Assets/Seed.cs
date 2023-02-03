using System;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class Seed : MonoBehaviour
{

  Rigidbody m_Rigidbody;
  [SerializeField] private Animator _animator;
  [SerializeField] private Rigidbody rigidbody;
  [SerializeField] private float shootStrengthModifier;

  private void OnTriggerEnter(Collider other)
  {
    _animator.SetTrigger("Breath");
    rigidbody.isKinematic = true;

    if (other.CompareTag("Floor"))
    {
      other.GetComponent<NavMeshSurface>().BuildNavMesh();
    }
  }

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    public void shoot(float strength) {
       
    
            Debug.Log("shooting " + strength);
        //m_Rigidbody.AddForce(transform.forward * strength * 100);
        m_Rigidbody.velocity = Vector3.forward * strength * shootStrengthModifier;
    
    }
}
