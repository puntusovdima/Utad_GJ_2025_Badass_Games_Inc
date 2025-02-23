using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseUp : MonoBehaviour
{
    public FinalPcUi pcUiScript;
    
    private void OnMouseUpAsButton()
    {
        pcUiScript.OpenLaptop();
        Debug.Log("OnMouseUpAsButton");
    }
}
