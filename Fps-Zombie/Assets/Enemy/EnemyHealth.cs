using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] float currentHealth;
    private void Awake()
    {
        currentHealth = health;
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        currentHealth -= damage;
        Debug.Log("health" + currentHealth);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
