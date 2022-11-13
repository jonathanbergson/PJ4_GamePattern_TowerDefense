using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyRedFlyweight : EnemyFlyweight
{
   public new int MaxLife = 5;
   public new float MaxSpeed = 8f;
}

public class EnemyBlueFlyweight : EnemyFlyweight
{
    public new int MaxLife = 8;
    public new float MaxSpeed = 4f;
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
