using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public Slider healSlider;
    private bool playerIsDeath;
    private Animator animator;
    private static int currentHealth;
    private bool damaged;
    public Image damageImage;
    private Color color = new Color(1F, 0F, 0F);
    public Text text;
    public delegate void PlayerDeathAction();
    public static event PlayerDeathAction PlayerDeathEvent;

    private void Awake()
    {
        healSlider.maxValue = health;
        if (currentHealth <= 0)
        {
            healSlider.value = health;
            currentHealth = health;
        }
        else
        {
            healSlider.value = health;
        }

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        damageImage.color = Color.Lerp(damageImage.color, Color.clear, Time.deltaTime * 5F);
    }

    public void TakeDamage(int damageAmount)
    {
        if (playerIsDeath) return;
        currentHealth -= damageAmount;
        healSlider.value = currentHealth;
        damageImage.color = color;

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        playerIsDeath = true;
        text.text = "DIE";      
        animator.SetTrigger("isDeath");
        GetComponent<PlayerController>().enabled = false;
        GetComponentInChildren<PlayerAttack>().enabled = false;
        PlayerDeathEvent?.Invoke();
    }
}
