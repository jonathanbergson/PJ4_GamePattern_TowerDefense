using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum TypeOfEnemy
{
   EnemyRed, EnemyBlue
}
public class Flyweight : MonoBehaviour
{
   private const int MaxLife = 11;
   private const float MaxSpeed = 11f;
   private Vector3 tower;

   private int currentLife;

   private void Start()
   {
      currentLife = Random.Range(0, MaxLife);
   }
}
