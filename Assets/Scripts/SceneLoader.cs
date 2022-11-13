using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Button play;
    [SerializeField] private Button back;

    private void Awake()
    {
        if(play)
            play.onClick.AddListener(delegate { Scene(1); });
        if(back)
            back.onClick.AddListener(delegate { Scene(0); });
    }
    public void Scene(int scene)
    {
       GameManager.Instance.ChangeScene(scene);
    }
}
