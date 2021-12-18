using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] float currentHealth;

    bool isDead = false;
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
            Die();
            Destroy(gameObject, 3f);
        }
    }

    public bool GetIsDead()
    {
        return isDead;
    }
    private void Die()
    {
        if(isDead){return;}
        isDead = true;
        GetComponent<Animator>().SetTrigger("Die");
       
    }

    

}
