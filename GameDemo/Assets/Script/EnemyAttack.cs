using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    private int attackDamage = 10;
    private PlayerHealth playerHealth;
    private bool canAttackRange;
    private float attackSpeed = 3f;
    private float timer;
    private Animator animator;

    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        animator.SetBool("EnemyAttack", canAttackRange);
        if (canAttackRange && timer >= attackSpeed)
        {
            Attack();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == playerHealth.tag)
        {
            canAttackRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == playerHealth.tag)
        {
            canAttackRange = false;
        }
    }

    private void Attack()
    {
        timer = 0;
        playerHealth.TakeDamage(attackDamage);
    }

    private void playerIsDeath()
    {
        animator.SetTrigger("PlayIsDeath");
        GetComponent<EnemyController>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
    }

    private void OnEnable()
    {
        PlayerHealth.PlayerDeathEvent += playerIsDeath;
    }

    private void OnDisable()
    {
        PlayerHealth.PlayerDeathEvent -= playerIsDeath;
    }
}
