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
        HideTasks();
    }

    void Update()
    {
        
    }


    public void HideTasks()
    {
        anim.SetTrigger("Hide");
    }

    public void SetSubtask(string newSubtask)
    {
        subtask.text = newSubtask;
    }

    public IEnumerator UpdateSubtask(string newSubtask)
    {
        float seconds = 90f;
        seconds = seconds / 120;

        anim.SetTrigger("Update");
        yield return new WaitForSeconds(seconds);
        subtask.text = "· " + newSubtask;
        yield return new WaitForSeconds(0.51f);
    }
}
