using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int p_Health = 100;
    [SerializeField] int curr_p_Health = 0;

    void Awake()
    {
        curr_p_Health = p_Health;
    }

    public void TakeDamageFromEnemy(int damage)
    {
        curr_p_Health -= damage;
        if (curr_p_Health <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}
