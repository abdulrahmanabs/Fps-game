using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(Interactable), true)]
public class InteractableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Interactable[] interactables = FindObjectsOfType<Interactable>();
        foreach(var i in interactables){
            i.gameObject.layer=LayerMask.NameToLayer("Interactable");
        }

        Interactable interactable = (Interactable)target;

        if(interactable.GetType()==typeof(InteractionWithEventsOnly)){
            interactable.promptMessage=EditorGUILayout.TextField("Prompt Message",interactable.promptMessage);
            EditorGUILayout.HelpBox("InteractionWithEventsOnly can ONLY USE unity Events",MessageType.Info);
            if(interactable.GetComponent<InteractionEvent>()==null)
            {
                interactable.useUnityEvents=true;
                interactable.AddComponent<InteractionEvent>();
            }
        }

        else
        {
            if (interactable.useUnityEvents)
            {
                if (interactable.GetComponent<InteractionEvent>() == null)
                    interactable.gameObject.AddComponent<InteractionEvent>();
            }
            else
            {
                DestroyImmediate(interactable.GetComponent<InteractionEvent>());
            }
            base.OnInspectorGUI();
        }

    }
}
