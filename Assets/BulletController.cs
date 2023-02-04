using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;

    private void Start()
    {
        _rigidbody.velocity = transform.forward * _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
          //  GameManager.Instance.RemoveCircle();
          //  other.GetComponent<Blinkable>().Blink();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
