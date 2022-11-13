using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
     //public Flyweight flyweight;
     private int life;
     private float speed;
     [SerializeField] Transform tower;
     [SerializeField] NavMeshAgent navMeshAgent;
    

     private void Start()
     {
         /* life = flyweight.maxLife;
          speed = flyweight.maxSpeed;

          tower = flyweight.tower;*/
         speed = 2;
         navMeshAgent.speed = speed;
         navMeshAgent.SetDestination(tower.position);
     }
}
