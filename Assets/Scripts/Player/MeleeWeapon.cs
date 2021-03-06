﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{

    [SerializeField] private int damage = 40;
    private Collider col;

    private void Awake()
    {
        col = GetComponent<Collider>();
        col.enabled = false;
    }
    public void AttackStart()
    {
        col.enabled = true;
    }
    public void AttackEnd()
    {
        col.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Damageable damageable = other.GetComponent<Damageable>();

        if (damageable != null)
        {
            damageable.DoDamage(damage);
        }
    }
}
