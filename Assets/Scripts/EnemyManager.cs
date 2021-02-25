using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Damageable))]
public class EnemyManager : MonoBehaviour
{
    [SerializeField] private int health = 100;

    Animator animator;
    Damageable damageable;
    void Start()
    {
        animator = GetComponent<Animator>();
        damageable = GetComponent<Damageable>();

        damageable.OnRecieveDamage += RecieveDamage;
    }

    private void RecieveDamage(int damage)
    {
        animator.SetTrigger("Hit");
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
