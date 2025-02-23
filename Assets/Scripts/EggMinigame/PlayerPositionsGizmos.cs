using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionsGizmos : MonoBehaviour
{
    public GameObject[] playerPositions = new GameObject[4];
    public ActivateCatchPosition actCatchPos;

    private void Update()
    {
        for (int i = 0; i < playerPositions.Length; i++)
        {
            playerPositions[i].SetActive(actCatchPos.catchPositions[i].enabled);
        }
    }
}
