using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Transform actionAnchor;
    public float anchorSizeX = 2f;
    public float anchorSizeY = 2f;
    public bool showGizmos = true;
    public LayerMask interactLayer;
    public InteractButton interactButton;

    private void Start()
    {
        // interactLayer= LayerMask.NameToLayer("Interactions");
        interactLayer = LayerMask.GetMask("Interactions");
    }

    private void Update()
    {
        Interact();
    }


    private void Interact()
    {
        Collider2D hit = Physics2D.OverlapBox(actionAnchor.position, new Vector2(anchorSizeX, anchorSizeY), 0, interactLayer);
        if (hit != null)
        {
            Debug.Log("I am going to interact with: " + hit.name);
            interactButton = hit.gameObject.GetComponent<InteractButton>();
            interactButton.ShowButton(true);
        }
        else if (hit == null && interactButton != null)
        {
            interactButton.ShowButton(false);
            interactButton = null;
        }

    }
    private void OnDrawGizmos()
    {
        if (!showGizmos) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(actionAnchor.position, new Vector3(anchorSizeX, anchorSizeY, 0));
    }
}
