using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class checkLibrary : MonoBehaviour
{
    public PlayerMovement player;
    public InteractionsManager interactionsManager;
    bool set = false;

    void Update()
    {
        if (!set)
        {
            try
            {
                if (interactionsManager.GetState() == 1) {
                    player.GetComponent<Animator>().runtimeAnimatorController = player.animAnim.runtimeAnimatorController;
                    set = true;
                }
                else if (interactionsManager.GetState() == 2){
                    if (!Camera.main.GetComponent<ComputerSceneTransition>().zoom)
                    {
                        interactionsManager.SetState(3);
                        interactionsManager.CutsceneManager.PlayCutscene3();
                        set = true;
                    }
                    else player.transform.position = new Vector3(68f, -3.06f, 0);
                }
                else if (interactionsManager.GetState() == 4)
                {
                    if (!Camera.main.GetComponent<ComputerSceneTransition>().zoom)
                    {
                        interactionsManager.SetState(5);
                        interactionsManager.CutsceneManager.PlayCutscene6();
                        set = true;
                    }
                    else player.transform.position = new Vector3(68f, -3.06f, 0);

                }
            }
            catch { };
        }
    }
}
