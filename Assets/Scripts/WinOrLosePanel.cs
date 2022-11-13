using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinOrLosePanel : MonoBehaviour
{
    [SerializeField] private Material[] skyboxes;
    [SerializeField] private TextMeshProUGUI winOrLoseText;

    public bool win;

    private void Start()
    {
        if (win)
        {
            RenderSettings.skybox = skyboxes[0];
            winOrLoseText.text = "Você ganhou :D";
        }
        else
        {
            RenderSettings.skybox = skyboxes[1];
            winOrLoseText.text = "Você perdeu D:";
        }
        
    }
}
