﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHelper : MonoBehaviour
{
    [SerializeField] private MeleeWeapon weapon;
    Animator animator;
    private bool checkCombo;
    private bool isAttacking;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isAttacking)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (checkCombo)
            {
                animator.SetTrigger("Attack1");
            }
            else
            {
                animator.SetTrigger("Attack");
            }
        }
    }


    public void MeleeAttackStart()
    {
        isAttacking = true;
        weapon.AttackStart();
    }

    public void MeleeAttackEnd()
    {
        isAttacking = false;
        weapon.AttackEnd();
        animator.ResetTrigger("Attack");
    }

    public void ComboStart()
    {
        checkCombo = true;
    }

    public void ComboEnd()
    {
        checkCombo = false;
    }
}