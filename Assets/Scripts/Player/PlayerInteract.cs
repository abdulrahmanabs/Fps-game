
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] float rayLength=2;
    [SerializeField] LayerMask interactingLayer;
     PlayerUI playerUi;
     InputManager inputManager;

    Camera cam; 
    void Awake()
    {
        cam = Camera.main;
    }
    // Start is called before the first frame update
    void Start()
    {
        playerUi=GetComponent<PlayerUI>();
        inputManager= GetComponent<InputManager>();
    }

    Ray ray;
    void Update()
    {
        Interact();
    }

    private void Interact()
    {
        playerUi.ShowPromptMessage("");
        ray = new Ray(cam.transform.position, cam.transform.forward * rayLength);
        Debug.DrawRay(cam.transform.position, cam.transform.forward * rayLength);
        if (Physics.Raycast(ray, out RaycastHit hit, interactingLayer))
        {
            if (hit.transform.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hit.transform.GetComponent<Interactable>();
                playerUi.ShowPromptMessage(interactable.promptMessage);
                if(inputManager.playerActions.OnFoot.Interact.triggered){
                    interactable.BaseInteract();
                }
            }
        }
    }
}
