using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager 
{
    public static UnityEvent UseStep = new UnityEvent();
    public static UnityEvent<int> ChangeTextStep = new UnityEvent<int>();
    public static UnityEvent GameOver = new UnityEvent();
    public static UnityEvent Win = new UnityEvent();
    public static UnityEvent NextLvl = new UnityEvent();
    public static UnityEvent Restart = new UnityEvent();
}
