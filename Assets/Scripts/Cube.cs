using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Interactable
{
    
    protected override void Interact()
    {
        print("Interacted with "+ gameObject.name);
    }
}
