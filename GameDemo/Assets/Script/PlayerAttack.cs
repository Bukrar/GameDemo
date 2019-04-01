using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage = 20;
    private Animator animator;
    private EnemyHealth enemyHealth;
    private bool canAttackRange;

    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyHealth = enemy.GetComponent<EnemyHealth>();
    }

    void Update()
    {
        bool IsAttack = Input.GetButtonDown("Fire1");
        animator.SetBool("IsAttack", IsAttack);

        if (Input.GetButtonDown("Fire1"))
        {
            enemyHealth.TakeDamage(damage);
        }
    }

    private void Attack()
    {
       // enemyHealth.b = enemyHealth.b - 5;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == enemyHealth.tag)
        {
            canAttackRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == enemyHealth.tag)
        {
            canAttackRange = false;
        }
    }


}
