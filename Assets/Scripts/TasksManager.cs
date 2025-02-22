using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [Header("References")]
    public TMPro.TextMeshProUGUI subtask;
    public Animator anim;

    void Start()
    {
        
    }

    void Update()
    {
        
    }


    public void EndQuitTasks()
    {
        anim.SetTrigger("Quit");
    }

    public void SetSubtask(string newSubtask)
    {
        subtask.text = newSubtask;
    }

    public void UpdateSubtask(string newSubtask)
    {
        StartCoroutine(UpdateSubtaskCoroutine(newSubtask));
    }
    public IEnumerator UpdateSubtaskCoroutine(string newSubtask)
    {
        float seconds = 90f;
        seconds = seconds / 120;

        anim.SetTrigger("Update");
        yield return new WaitForSeconds(seconds);
        subtask.text = "· " + newSubtask;
        yield return new WaitForSeconds(0.51f);
    }
}
