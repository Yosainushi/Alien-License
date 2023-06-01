using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonController : MonoBehaviour
{
   public static JsonController instanse;

   public void Awake()
   {
      instanse = this;
   }
    
   public int item;

   [ContextMenu("Load")]

   public void LoadField()
   {
      string path = Application.persistentDataPath + "JSON.json";
      Item _item = new Item();
      if (File.Exists(path))
      {
         _item = JsonUtility.FromJson<Item>(File.ReadAllText(path));
         item = _item.LVL;
      }
      else
      {
         item = 0;
      }
        
   }
   [ContextMenu("Save")]
   public void SaveField()
   {
      string path = Application.persistentDataPath + "JSON.json";
      Item _item = new Item();
      _item.LVL = item;
      File.WriteAllText(path, JsonUtility.ToJson(_item));
   }
   public class  Item
   {
      public int LVL;
   }
}
