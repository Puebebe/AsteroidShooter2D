﻿using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Text scoreUI;
    [SerializeField] GameObject lossUI;
    [SerializeField] GameObject restartButton;

    void Start()
    {
        GameState.GameEnded += lossUI.SetActive;
        GameState.GameEnded += restartButton.SetActive;
    }
}