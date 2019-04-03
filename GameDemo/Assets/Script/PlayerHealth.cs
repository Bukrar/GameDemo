using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public  int health = 100;
    private bool playerIsDeath;
    private Animator animator;
 
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
    }
}
