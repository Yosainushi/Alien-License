using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CounterSteps : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        EventManager.ChangeTextStep.AddListener(ChangeValue);
    }

    
    private void ChangeValue(int value)
    {
        text.text = "Steps left: " + value;
    }
}
