using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{

  [SerializeField] private Animator _animator;
  [SerializeField] private Rigidbody rigidbody;

  private void OnTriggerEnter(Collider other)
  {
    _animator.SetTrigger("Breath");
    rigidbody.isKinematic = true;
  }
}
