using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] float ballistaDamage = 10;
    [SerializeField] float turretDamage = 15;
    [Tooltip("Adds amount to max Hit Points when enemy dies")]
    [SerializeField] int difficultyRamp = 1;
    [SerializeField] private HealthBar healthBar;
    

    int damage;
    float currentHealth = 0;

    Enemy enemy;

    void OnEnable()
    {
        currentHealth = health;

        healthBar.UpdateHealthBar(health, currentHealth);
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.tag == "Ballista")
        {
            
            ProcessHit(ballistaDamage);
        }
        else if (other.tag == "Turret")
        {
            ProcessHit(turretDamage);
        }
    }

    private void ProcessHit(float damage)
    {
        currentHealth = currentHealth - damage;
        healthBar.UpdateHealthBar(health, currentHealth);

        if (currentHealth <= 0)
        {
            enemy.RewardGold();
            health += difficultyRamp;
            gameObject.SetActive(false);
        }
    }
}
