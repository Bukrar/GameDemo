using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage = 20;
    private Animator animator;
    private Animator enemyAnimator;
    private EnemyHealth enemyHealth;
    private bool canAttackRange;
    private float timer;
    private float AttackSpeed = 0.5f;

    private void Start()
    {
       
    }

    private void Awake()
    {
        animator = GetComponentInParent<Animator>();       
    }

    void Update()
    {
        timer += Time.deltaTime;
        bool IsAttack = Input.GetButtonDown("Fire1");
        animator.SetBool("IsAttack", IsAttack);
        enemyAnimator.SetBool("IsDamage", canAttackRange && IsAttack && timer >= AttackSpeed);
        if (canAttackRange && IsAttack && timer >= AttackSpeed)
        {
            Attack();
        }
    }

    private void Attack()
    {
        timer = 0;
        enemyHealth.TakeDamage(damage);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemyAnimator = other.GetComponent<Animator>();
            enemyHealth = other.GetComponent<EnemyHealth>();
            canAttackRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            canAttackRange = false;
        }
    }


}
