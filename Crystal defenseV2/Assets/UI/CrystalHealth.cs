using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CrystalHealth : MonoBehaviour
{
    [Header("Health Bar :")]
    public Slider healthBar;

    [Header("Max Health Amount :")]
    [Range(1f, 100f)]
    public float maxHealth;

    [Header("Enemy Damage Amount :")]
    [Range(0.1f, 5f)]
    public float enemyDamageValue;

    [Header("Damage Cooldown Time :")]
    [Range(0.1f, 5f)]
    public float damageCooldownTime;

   /* [Header("Damage Effect :")]
    public GameObject damageEffect;*/

    [HideInInspector]
    public float currentHealth;


    private bool isDamageable;

    private void Start()
    {
        healthBar.maxValue = maxHealth;
        isDamageable = true;
        currentHealth = maxHealth;
        healthBar.value = currentHealth;
    }

    public void Update()
    {
        if(currentHealth <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }



    public IEnumerator TakeDamage(float damage)
    {
        Debug.Log(currentHealth);
        isDamageable = false;
        currentHealth -= damage;
        healthBar.value = currentHealth;
        yield return new WaitForSeconds(damageCooldownTime);
        isDamageable = true;
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Collision met : " + other);
        if (other.gameObject.CompareTag("Enemy") && isDamageable && currentHealth > 0)
        {
            Debug.Log("TakeDamge IEnumerator;");
            StartCoroutine(TakeDamage(enemyDamageValue));
        }
    }
}
