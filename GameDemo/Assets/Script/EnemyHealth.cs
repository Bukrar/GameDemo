using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public int heal = 100;
    private bool isDeath;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isDeath);
    }

    public void TakeDamage(int DamageAmount)
    {
        if (isDeath)
        {
            return;
        }
        Debug.Log("T");
        heal -= DamageAmount;
        if (heal <= 0)
        {
            Death();
        }
    }   

    private void Death()
    {        
        isDeath = true;
        animator.SetTrigger("IsDeath");
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<EnemyAttack>().enabled = false;
        GetComponent<EnemyController>().enabled = false;
    }
}
