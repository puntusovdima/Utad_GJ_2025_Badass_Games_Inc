using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
   public static StateManager instance;
   
   public int state = 1;
   public enum GameState {Cutscene, FreeRoam, Dialog}

   public bool[] dialogsCompleted = new bool[7];
   public GameState gameState;
    public int miniGameCompleteCount;
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

    public void CompleteMiniGame()
    {
        miniGameCompleteCount++;
    }

   public void MarkAsSpoke(int index)
   {
      dialogsCompleted[index] = true;
   }

   public void ResetDialogs()
   {
      for (int i = 0; i < dialogsCompleted.Length; i++)
      {
         dialogsCompleted[i] = false;
      }
   }
   public bool CheckIfSpokenWithAll()
   {
      bool allSpoken = false;
      for (int i = 0; i < dialogsCompleted.Length; i++)
      {
         if (dialogsCompleted[i] == true)
         {
            allSpoken = true;
         }
         else
         {
            allSpoken = false;
            break;
         }
      }
      return allSpoken;
   }
}
