using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Movable item settings")] 
    [SerializeField] internal float speedObjects;

    [SerializeField] internal float maxDistance; //value for checking if an object can be moved

    public static GameManager instanse;

    private void Awake()
    {
        instanse = this;
    }
}
