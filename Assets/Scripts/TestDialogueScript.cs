using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogueScript : MonoBehaviour
{
    [SerializeField] DialogManager dialogManager;

    void Start()
    {
        dialogManager.NewDialog("Hi! Lorem Ipsum, ladies and gentlemen", 0, true);
    }

    void Update()
    {
        
    }
}
