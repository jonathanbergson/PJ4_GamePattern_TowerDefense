using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public static GameObject CreateObject(GameObject enemy)
    {
        return enemy;
    }
}

