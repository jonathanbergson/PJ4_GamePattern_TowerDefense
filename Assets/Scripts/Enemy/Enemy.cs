using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMeshAgent;
    int life;
    private Transform target;
    
    public void SetType(EnemyFlyweight type)
    {
        life = type.MaxLife;
        navMeshAgent.speed = type.MaxSpeed;
        target = type.Tower.transform;

        navMeshAgent.SetDestination(target.position);
    }

    private void OnTriggerEnter(Collider other)
     {
         if (other.CompareTag("Bullet"))
         {
             life--;
             if (life <= 0)
             {
                 Tower.Tower.Instance.AddScore();
                 Destroy(gameObject);
             }
         }

         if (other.CompareTag("Tower"))
         {
             Tower.Tower.Instance.LoseLifes();
             Destroy(gameObject);
         }
     }
}
