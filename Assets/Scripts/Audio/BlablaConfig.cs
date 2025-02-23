using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Blabla Config")]
public class BlablaConfig : ScriptableObject
{
    [SerializeField] List<AudioClip> beeps = new List<AudioClip>();
    public float minPitch;
    public float maxPitch;

    public AudioClip GetRandomClip()
    {
        return beeps[Random.Range(0, beeps.Count)];
    }
    public float GetRandomPitch()
    {
        return Random.Range(minPitch, maxPitch);
    }
}
