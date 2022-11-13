using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMeshAgent;
    private int life;

     public void SetType(EnemyFlyweight type)
     {
         life = type.MaxLife;
         navMeshAgent.speed = type.MaxSpeed;
         navMeshAgent.SetDestination(type.Tower.position);
     }

     private void Update()
     {
         if (life <= 0)
         {
             Destroy(gameObject);
             //pontuaçao
         }
     }
}
