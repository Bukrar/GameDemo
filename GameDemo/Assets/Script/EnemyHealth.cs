using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int heal = 100;
    private bool isDeath;
    // Start is called before the first frame update
    void Start()
    {
        
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
        Debug.Log("D");
        isDeath = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
