using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// code obtained from Brackley's YouTube video on How to make a Dialogue System in Unity

public class DialogueManager : MonoBehaviour
{
	public Text dialogueText;
	public GameObject textBox;
    public Button continueButt;

	// public Animator animator;

	private Queue<string> sentences;

	// Use this for initialization
	void Start()
	{
		sentences = new Queue<string>();
        continueButt.gameObject.SetActive(false);
        textBox.SetActive(false);
        dialogueText.text = "";
    }

	public void StartDialogue(Dialogue dialogue)
	{
        continueButt.gameObject.SetActive(true);
        textBox.SetActive(true);
        Time.timeScale = 0;
        // animator.SetBool("IsOpen", true);

        sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
        Debug.Log("Thank you, next.");
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{
        dialogueText.text = "";
        textBox.SetActive(false);
        Time.timeScale = 1;
        continueButt.gameObject.SetActive(false);
        //animator.SetBool("IsOpen", false);
    }

}
