using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] internal int countSteps;

    private int countStepsLeft;

    public int CountStepsLeft
    {
        get => countStepsLeft;

        set
        {
            countStepsLeft = value;
            if (countStepsLeft>0) //check for lose and set counter value
            {
                EventManager.ChangeTextStep.Invoke(value);
            }
            else
            {
                EventManager.ChangeTextStep.Invoke(value);
                EventManager.GameOver.Invoke();
            }
        }
    }
    void Awake()
    {
        EventManager.UseStep.AddListener(UseStep);
        countStepsLeft = countSteps;
    }


    private void UseStep()
    {
        CountStepsLeft--;
    }
}
