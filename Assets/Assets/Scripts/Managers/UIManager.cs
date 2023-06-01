using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject winScreen;

    private void Start()
    {
        EventManager.GameOver.AddListener(Lose);
        EventManager.Win.AddListener(Win);
    }

    public void Nextlvl()
    {
        winScreen.SetActive(false);
        EventManager.NextLvl.Invoke();
    }
    public void Restart()
    {
        loseScreen.SetActive(false);
        EventManager.Restart.Invoke();
    }
    private void Lose()
    {
        loseScreen.SetActive(true);
    }

    private void Win()
    {
        winScreen.SetActive(true);
    }
   
}
