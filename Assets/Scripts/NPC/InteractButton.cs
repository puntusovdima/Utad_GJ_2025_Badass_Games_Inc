using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractButton : MonoBehaviour
{
    public GameObject interactButton;
    public SpriteRenderer sr;

    private void Start()
    {
        interactButton = transform.GetChild(0).gameObject;
        sr = interactButton.GetComponent<SpriteRenderer>();
        // sr = GetComponent<SpriteRenderer>();
    }

    public void ShowButton(bool show)
    {
        sr.enabled = show;
    }
}
