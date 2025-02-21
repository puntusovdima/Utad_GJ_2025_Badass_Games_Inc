using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
   private static StateManager instance;
   
   public int state = 0;

   private void Awake()
   {
      if (instance != null)
      {
         Destroy(gameObject);
      }
      else {
         instance = this;
         DontDestroyOnLoad(gameObject);
      }
   }
}
