using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

   private void Start()
   {
      InvokeRepeating("UpdateStateInt", 0, 0.1f);
   }

   private void UpdateStateInt()
   {
      state = SceneManager.GetActiveScene().buildIndex;
      
   }
}
