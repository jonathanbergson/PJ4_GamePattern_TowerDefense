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
   public int maxLife = 11;
   public float maxSpeed = 11f;
   public Transform tower;
}
