using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public static GameObject CreateObject(GameObject enemy, int index)
    {
        if (index == 0)
            enemy.GetComponent<Enemy>().SetType(new EnemyRedFlyweight());
        else
            enemy.GetComponent<Enemy>().SetType(new EnemyBlueFlyweight());
        
        return enemy;
    }
}

