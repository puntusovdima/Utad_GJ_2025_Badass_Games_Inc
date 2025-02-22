using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCatchPosition : MonoBehaviour
{
    public Collider2D[] catchPositions = new Collider2D[4];
    // 0 left top 1 right top 2 right bottom 3 left bottom

    private void Start()
    {
        // catchPositions = GetComponentsInChildren<Collider2D>();
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                for (int i = 0; i < catchPositions.Length; i++)
                {
                    catchPositions[i].enabled = false;
                }
                catchPositions[1].enabled = true;
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                for (int i = 0; i < catchPositions.Length; i++)
                {
                    catchPositions[i].enabled = false;
                }
                catchPositions[2].enabled = true;
            }
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                for (int i = 0; i < catchPositions.Length; i++)
                {
                    catchPositions[i].enabled = false;
                }
                catchPositions[0].enabled = true;
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                for (int i = 0; i < catchPositions.Length; i++)
                {
                    catchPositions[i].enabled = false;
                }
                catchPositions[3].enabled = true;
            }
        }
        
    }
}
