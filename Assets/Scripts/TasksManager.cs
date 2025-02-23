using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [Header("References")]
    public DialogManager DialogManager;
    public TMPro.TextMeshProUGUI subtask;
    public Animator anim;
    List<string> taskQueue = new List<string>();

    void Start()
    {
        StartCoroutine(checkTasks());
    }

    public void NewTask(string task)
    {
        taskQueue.Add(task);
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
        subtask.text = newSubtask;
        yield return new WaitForSeconds(0.51f);
    }

    public IEnumerator checkTasks()
    {
        while (true) {
            if (taskQueue.Count > 0 && !DialogManager.isConversation)
            {
                UpdateSubtask(taskQueue[0]);
                taskQueue.RemoveAt(0);
                yield return new WaitForSecondsRealtime(2);
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
