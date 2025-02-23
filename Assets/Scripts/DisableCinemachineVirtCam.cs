using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class DisableCinemachineVirtCam : StateMachineBehaviour
{
    public CinemachineVirtualCamera vcam;
    public PlayerMovement playerMovement;
    public InteractionsManager interactionsManager;
    public Vector3 cmPosition = new Vector3(-6.2f, -0.15f, -10);
    Transform follow;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        vcam = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        interactionsManager = GameObject.FindObjectOfType<InteractionsManager>();
        playerMovement.enabled = false;
        vcam.enabled = false;
        vcam.transform.position = cmPosition;
        vcam.gameObject.SetActive(false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        vcam.gameObject.SetActive(true);
        vcam.enabled = true;
        playerMovement.enabled = true;
        interactionsManager.Begining();
        // animator.enabled = false;
        animator.runtimeAnimatorController = playerMovement.animatorController;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
