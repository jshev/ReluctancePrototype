using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// code obtained from Brackley's YouTube video on How to make a Dialogue System in Unity

public class DialogueManager : MonoBehaviour
{
	public Text dialogueText;
    public Text consequences;
	public GameObject textBox;
    public Button continueButt;
    public Dialogue dig;

    public Button[] toIDbuttons;
    //toID5, toID6, toID7, toID8, toID9, toNowhere

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
        disableAllButtons();
        dig = dialogue;
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

    void disableAllButtons()
    {
        foreach (Button butt in toIDbuttons)
        {
            butt.gameObject.SetActive(false);
        }
    }

	void EndDialogue()
	{
        switch (dig.id)
        {
            case 4:
                disableAllButtons();
                continueButt.gameObject.SetActive(false);
                // toID9 and toID8
                toIDbuttons[3].gameObject.SetActive(true);
                toIDbuttons[4].gameObject.SetActive(true);
                break;
            case 6:
                disableAllButtons();
                continueButt.gameObject.SetActive(false);
                // toNoWhere and toID7
                toIDbuttons[2].gameObject.SetActive(true);
                toIDbuttons[5].gameObject.SetActive(true);
                break;
            case 8:
                consequences.text = "Your relationship with this character has weakened...";
                disableAllButtons();
                dialogueText.text = "";
                textBox.SetActive(false);
                Time.timeScale = 1;
                continueButt.gameObject.SetActive(false);
                break;
            case 9:
                disableAllButtons();
                continueButt.gameObject.SetActive(false);
                // toID5, toID6, and to ID8
                toIDbuttons[0].gameObject.SetActive(true);
                toIDbuttons[1].gameObject.SetActive(true);
                toIDbuttons[3].gameObject.SetActive(true);
                break;
            default:
                disableAllButtons();
                dialogueText.text = "";
                textBox.SetActive(false);
                Time.timeScale = 1;
                continueButt.gameObject.SetActive(false);
                break;
        }
    }

}
