using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    public Health health;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        health.DamagePlayer(30.0f);
    }
}
