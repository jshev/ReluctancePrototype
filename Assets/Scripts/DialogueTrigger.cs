using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// code obtained from Brackley's YouTube video on How to make a Dialogue System in Unity

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        Debug.Log("Triggered!");
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}