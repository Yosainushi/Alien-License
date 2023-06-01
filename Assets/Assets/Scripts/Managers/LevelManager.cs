using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Level[] Levels = default;
    public bool isWork;
    private int curLevelNumber=0;
    private Level curLvlObject;
    void Start()
    {
        if (isWork) //to test current levels
        {
            EventManager.NextLvl.AddListener(NextLvl);
            EventManager.Restart.AddListener(RestartLvl);  
            JsonController.instanse.LoadField();
            curLevelNumber = JsonController.instanse.item;
            SpawnLevel(curLevelNumber);
        }
       
    }
    public void SpawnLevel(int lvl)
    {
        if (curLvlObject != null)  //for restart
        {
            Destroy(curLvlObject.gameObject);
            curLvlObject=Instantiate(Levels[lvl]);
        }
        else //for other situations
        {
            curLvlObject=Instantiate(Levels[lvl]);
        }
        EventManager.ChangeTextStep.Invoke(curLvlObject.CountStepsLeft); //set counter
    }

    public void NextLvl()  // load new lvl and save value 
    {
        curLevelNumber++;
        if (Levels.Length-1<curLevelNumber)
        {
            curLevelNumber = 0;
        }
        JsonController.instanse.item = curLevelNumber;
        JsonController.instanse.SaveField();                
        JsonController.instanse.LoadField();
        Destroy(curLvlObject.gameObject);
        SpawnLevel(JsonController.instanse.item);
    }
    public void RestartLvl()
    {
        SpawnLevel(curLevelNumber);
    }
    
}
