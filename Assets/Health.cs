using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    public float curHealth = 0.0f;
    public float maxHealth = 100.0f;

    public HealthBar healthBar;

    void Start()
    {
        curHealth = maxHealth;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DamagePlayer(10.0f);
        }
    }

    public void DamagePlayer(float damage)
    {
        curHealth -= damage;

        healthBar.SetHealth(curHealth / maxHealth);
    }
}
