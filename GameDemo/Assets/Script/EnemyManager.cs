using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    public float BornMonsterTime = 5f;
    public float repeatRate = 3f;
    public Transform[] monsterPoint;
    private bool playerIsDeath;
    
    private void playerDeathAction()
    {
        playerIsDeath = true;
    }

    private void Spawn()
    {
        if (playerIsDeath)
        {
            CancelInvoke("Spawn");
            return;
        }

        int pointIndex = Random.Range(0, monsterPoint.Length);
        Instantiate(enemy, monsterPoint[pointIndex].position,
            monsterPoint[pointIndex].rotation);
            
    }

    private void Start()
    {
        InvokeRepeating("Spawn", BornMonsterTime, repeatRate);
    }
}
