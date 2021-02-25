using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHelper : MonoBehaviour
{
    [SerializeField] private MeleeWeapon weapon;
    bool checkCombo;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
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
        
        weapon.AttackStart();
    }
    public void MeleeAttackEnd()
    {
        weapon.AttackEnd();
        animator.ResetTrigger("Attack");

    }
    void CoboStart()
    {
        checkCombo = true;
    }
    public void ComboEnd()
    {
        checkCombo = false;
    }
}
