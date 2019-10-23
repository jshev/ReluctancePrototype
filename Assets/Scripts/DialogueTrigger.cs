using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// code obtained from Brackley's YouTube video on How to make a Dialogue System in Unity

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;
    bool once = true;

    public void TriggerDialogue()
    {
        Debug.Log("Triggered!");
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Hit Player");
            if (once)
            {
                //Debug.Log("Triggered???");
                TriggerDialogue();
                once = false;
            }
            
        }
    }

}