using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Interactable : MonoBehaviour
{
    public bool useUnityEvents=false;
    public string promptMessage="";
    public void BaseInteract(){
        if(useUnityEvents)
            GetComponent<InteractionEvent>().onInteract.Invoke();
        Interact();
    }

    protected virtual void Interact(){
        
    }
}
