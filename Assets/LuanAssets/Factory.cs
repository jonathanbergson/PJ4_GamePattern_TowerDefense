using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public static GameObject CreateObject(GameObject enemy)
    {
        //enemy.GetComponent<Enemy>().speed = FlyWeight.maxSpeed; 


        /*GameObject obj = new GameObject();
        obj.AddComponent<MeshRenderer>();
        obj.AddComponent<MeshFilter>();
        obj.GetComponent<MeshFilter>().mesh = mesh;
        obj.GetComponent<MeshRenderer>().material = material;
        obj.AddComponent<Rigidbody>();
        obj.AddComponent<BoxCollider>();*/
        return enemy;
    }
}

