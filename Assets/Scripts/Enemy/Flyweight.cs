using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyRedFlyweight : EnemyFlyweight
{
   public int _MaxLife = 3;
   public float _MaxSpeed = 4f;
   
   public EnemyRedFlyweight()
   {
       this.MaxLife = _MaxLife;
       this.MaxSpeed = _MaxSpeed;
   }
}

public class EnemyBlueFlyweight : EnemyFlyweight
{
    public int _MaxLife = 6;
    public float _MaxSpeed = 2f;

    public EnemyBlueFlyweight()
    {
        this.MaxLife = _MaxLife;
        this.MaxSpeed = _MaxSpeed;
    }
}
public abstract class EnemyFlyweight
{
    public int MaxLife;
    public float MaxSpeed;
    public Transform Tower;

    public EnemyFlyweight()
    {
        Tower = GameObject.FindGameObjectWithTag(Constants.TagTower).transform;
    }
}
