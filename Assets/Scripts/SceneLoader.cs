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
            play.onClick.AddListener(Game);
        if(back)
            back.onClick.AddListener(Initial);
    }

    public void Game()
    {
       GameManager.Instance.ChangeScene(1);
    }
    public void Initial()
    {
        GameManager.Instance.ChangeScene(0);
    }

    public void GoToEnd()
    {
        GameManager.Instance.ChangeScene(2);
    }
}
