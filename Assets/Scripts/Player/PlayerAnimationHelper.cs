using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHelper : MonoBehaviour
{
    [SerializeField] private MeleeWeapon weapon;

    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void MeleeAttackStart()
    {
        weapon.AttackStart();
    }
    public void MeleeAttackEnd()
    {
        weapon.AttackEnd();
        animator.ResetTrigger("Attack");
    }
}
