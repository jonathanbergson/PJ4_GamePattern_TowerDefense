using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryTeste : MonoBehaviour
{
    /*public Mesh[] meshs;
    public Material[] materials;*/

    public GameObject[] enemys;
    public Transform[] spawners;
    public int spawnindex, spawnCount;

    bool canCall = true;
    IEnumerator Spaw()
    {    
        for (int i = 0; i < spawnCount; i++)
        {
            Debug.Log("Corrotina");
            Instantiate(Factory.CreateObject(enemys[spawnindex]), spawners[Random.Range(0, spawners.Length)]);
            yield return new WaitForSeconds(1f);
        }
        canCall = true;
    }

    public void Update()
    {       
        if (Input.GetKeyDown(KeyCode.S) && canCall)
        {
            StartCoroutine(Spaw());
            canCall = false;          
        }       
    }
}
