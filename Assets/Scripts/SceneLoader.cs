using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Button play;

    private void Awake()
    {
        play.onClick.AddListener(Game);
    }

    public void Game()
    {
        SceneManager.LoadScene(1);
    }
}
