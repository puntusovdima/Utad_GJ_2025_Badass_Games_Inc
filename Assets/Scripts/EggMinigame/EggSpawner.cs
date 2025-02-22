using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EggSpawner : MonoBehaviour
{
    // 0 left top 1 right top 2 right bottom 3 left bottom

    public GameObject topEggPrefab;
    public GameObject bottomEggPrefab;
    public Transform[] spawnPoints = new Transform[4];
    public float spawnRate = 3f;
    private float currentTime;
    private void Start()
    {
        currentTime = 0f;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= Random.Range(1f, spawnRate))
        {
            int index = Random.Range(0, spawnPoints.Length);
            if (index > 1)
            {
                Instantiate(bottomEggPrefab, spawnPoints[index].position, Quaternion.identity);
            }
            else
            {
                Instantiate(topEggPrefab, spawnPoints[index].position, Quaternion.identity);
            }
            currentTime = 0f;
        }
    }
}
