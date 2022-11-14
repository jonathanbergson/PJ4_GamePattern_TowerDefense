using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FactoryTeste : MonoBehaviour
{
    public GameObject[] enemys;
    public Transform[] spawners;
    int spawnCount;
    private int spawnIndex = 0;

    private void Start()
    {
        spawnCount = 6;
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            spawnIndex = Random.Range(0, 2);
            GameObject enemy = Instantiate(Factory.CreateObject(enemys[spawnIndex]), spawners[Random.Range(0, spawners.Length)]);
            
            if (spawnIndex == 0)
                enemy.GetComponent<Enemy>().SetType(new EnemyRedFlyweight());
            else
                enemy.GetComponent<Enemy>().SetType(new EnemyBlueFlyweight());
            
            yield return new WaitForSeconds(0.5f);
        }

        spawnCount += 3;
        yield return new WaitForSeconds(2f);

        if (spawnCount >= 12) yield break;
        StartCoroutine(Spawn());
    }
}