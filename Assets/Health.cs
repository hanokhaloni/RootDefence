using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    public float curHealth = 0.0f;
    public float maxHealth = 100.0f;

    public HealthBar healthBar;
    public GameOverManager gameOverManager;


    void Start()
    {
        curHealth = maxHealth;
    }

    void Update()
    {

    }

    public void DamagePlayer(float damage)
    {
        curHealth -= damage;

        healthBar.SetHealth(curHealth / maxHealth);

        if (curHealth < 0.0f)
        {
            gameOverManager.GameOver();
        }
    }
}
