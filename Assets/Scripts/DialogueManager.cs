using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// code obtained from Brackley's YouTube video on How to make a Dialogue System in Unity

public class DialogueManager : MonoBehaviour
{
	public Text dialogueText;
    public Text consequences;

    public GameObject environment;
    SpriteRenderer envSR;
    float currCountdownValue;

    public GameObject textBox;
    public Button continueButt;
    public GameObject phoneObj;
    public Sprite greyGrass;
    public Sprite grass;
    SpriteRenderer phoneSR;
    public Dialogue dig;

    public Button[] toIDbuttons;
    // toID5 (0), toID6 (1), toID7 (2), toID8 (3), toID9 (4), toNowhere (5), toID11 (6)
    // toID12 (7), toID13 (8), toNowhere(1) (8), toID14 (9), toID15 (10), toID16 (11), toID17 (12)
    // toNowhere(2) (13), toID18 (14), toID19 (15), toID20 (16), toID21 (18), toNowhere(3) (19)
    // toID22 (20), toID23 (21), toID24 (22), toID25 (23), toID26 (24), toID27 (25)
    // toID28 (26), toID29 (27), toID30 (28), toID31 (29)

    public Sprite[] messageSprites;
    // 9 Andrew, 5 Isabel = 14 (13) total

    bool once = true;

    // public Animator animator;

    private Queue<string> sentences;

	// Use this for initialization
	void Start()
	{
        disableAllButtons();
        sentences = new Queue<string>();
        continueButt.gameObject.SetActive(false);
        textBox.SetActive(false);
        dialogueText.text = "";
        envSR = environment.GetComponent<SpriteRenderer>();
        phoneSR = phoneObj.GetComponent<SpriteRenderer>();
        phoneObj.SetActive(false);
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
        // Debug.Log("Thank you, next.");
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
        //StartCoroutine(TypeSentence(sentence));
        dialogueText.text = sentence;

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
                switchWorld();
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
            case 10:
                disableAllButtons();
                continueButt.gameObject.SetActive(false);
                // toID11, toID12, and to ID13
                toIDbuttons[6].gameObject.SetActive(true);
                toIDbuttons[7].gameObject.SetActive(true);
                toIDbuttons[8].gameObject.SetActive(true);
                break;
            case 11:
                disableAllButtons();
                continueButt.gameObject.SetActive(false);
                // toNowhere(1), toID14, and to ID15
                toIDbuttons[9].gameObject.SetActive(true);
                toIDbuttons[10].gameObject.SetActive(true);
                toIDbuttons[11].gameObject.SetActive(true);
                break;
            case 12:
                consequences.text = "Your symptoms have worsened...";
                switchWorld();
                disableAllButtons();
                dialogueText.text = "";
                textBox.SetActive(false);
                Time.timeScale = 1;
                continueButt.gameObject.SetActive(false);
                break;
            case 13:
                disableAllButtons();
                continueButt.gameObject.SetActive(false);
                // toID16 and to ID17
                toIDbuttons[12].gameObject.SetActive(true);
                toIDbuttons[13].gameObject.SetActive(true);
                break;

            case 14:
                disableAllButtons();
                dialogueText.text = "";
                continueButt.gameObject.SetActive(false);
                phoneObj.SetActive(true);
                phoneSR.sprite = messageSprites[0];
                // toID23 and to ID24
                toIDbuttons[21].gameObject.SetActive(true);
                toIDbuttons[22].gameObject.SetActive(true);
                break;
            case 15:
                disableAllButtons();
                dialogueText.text = "";
                continueButt.gameObject.SetActive(false);
                phoneObj.SetActive(true);
                phoneSR.sprite = messageSprites[9];
                // toID30 (28) and toID31 (29)
                toIDbuttons[28].gameObject.SetActive(true);
                toIDbuttons[29].gameObject.SetActive(true);
                break;

            case 16:
                disableAllButtons();
                continueButt.gameObject.SetActive(false);
                // toNowhere(3) and toID22
                toIDbuttons[19].gameObject.SetActive(true);
                toIDbuttons[20].gameObject.SetActive(true);
                break;
            case 17:
                disableAllButtons();
                continueButt.gameObject.SetActive(false);
                // toNowhere(2), toID18, and to ID19
                toIDbuttons[14].gameObject.SetActive(true);
                toIDbuttons[15].gameObject.SetActive(true);
                toIDbuttons[16].gameObject.SetActive(true);
                break;
            case 18:
                disableAllButtons();
                continueButt.gameObject.SetActive(false);
                // toID20 and to ID21
                toIDbuttons[17].gameObject.SetActive(true);
                toIDbuttons[18].gameObject.SetActive(true);
                break;
            case 21:
                consequences.text = "Your relationship with this character has weakened...";
                switchWorld();
                disableAllButtons();
                dialogueText.text = "";
                textBox.SetActive(false);
                Time.timeScale = 1;
                continueButt.gameObject.SetActive(false);
                break;
            case 22:
                consequences.text = "Your relationship with this character has weakened..." + "\n" + "Your symptoms have worsened...";
                switchWorld();
                disableAllButtons();
                dialogueText.text = "";
                textBox.SetActive(false);
                Time.timeScale = 1;
                continueButt.gameObject.SetActive(false);
                break;

            case 23:
                if (once) {
                    disableAllButtons();
                    dialogueText.text = "";
                    continueButt.gameObject.SetActive(true);
                    phoneSR.sprite = messageSprites[1];
                    Debug.Log("Done");
                    once = false;
                    break;
                } else
                {
                    disableAllButtons();
                    dialogueText.text = "";
                    phoneObj.SetActive(false);
                    textBox.SetActive(false);
                    Time.timeScale = 1;
                    continueButt.gameObject.SetActive(false);
                    once = true;
                    Debug.Log(once);
                    break;
                }
            case 24:
                disableAllButtons();
                dialogueText.text = "";
                continueButt.gameObject.SetActive(false);
                phoneSR.sprite = messageSprites[2];
                // toID23 and to ID25
                toIDbuttons[21].gameObject.SetActive(true);
                toIDbuttons[23].gameObject.SetActive(true);
                break;
            case 25:
                disableAllButtons();
                dialogueText.text = "";
                continueButt.gameObject.SetActive(false);
                phoneSR.sprite = messageSprites[4];
                // toID26 and to ID27
                toIDbuttons[24].gameObject.SetActive(true);
                toIDbuttons[25].gameObject.SetActive(true);
                break;

            case 26:
                if (once)
                {
                    disableAllButtons();
                    dialogueText.text = "";
                    continueButt.gameObject.SetActive(true);
                    phoneSR.sprite = messageSprites[5];
                    Debug.Log("Done");
                    once = false;
                    break;
                }
                else
                {
                    consequences.text = "Your relationship with this character has weakened...";
                    switchWorld();
                    disableAllButtons();
                    dialogueText.text = "";
                    phoneObj.SetActive(false);
                    textBox.SetActive(false);
                    Time.timeScale = 1;
                    continueButt.gameObject.SetActive(false);
                    once = true;
                    Debug.Log(once);
                    break;
                }
            case 27:
                disableAllButtons();
                dialogueText.text = "";
                continueButt.gameObject.SetActive(false);
                phoneSR.sprite = messageSprites[6];
                // toID28 and to ID29
                toIDbuttons[26].gameObject.SetActive(true);
                toIDbuttons[27].gameObject.SetActive(true);
                break;
            case 28:
                if (once)
                {
                    disableAllButtons();
                    dialogueText.text = "";
                    continueButt.gameObject.SetActive(true);
                    phoneSR.sprite = messageSprites[7];
                    Debug.Log("Done");
                    once = false;
                    break;
                }
                else
                {
                    disableAllButtons();
                    dialogueText.text = "";
                    phoneObj.SetActive(false);
                    textBox.SetActive(false);
                    Time.timeScale = 1;
                    continueButt.gameObject.SetActive(false);
                    once = true;
                    Debug.Log(once);
                    break;
                }
            case 29:
                if (once)
                {
                    disableAllButtons();
                    dialogueText.text = "";
                    continueButt.gameObject.SetActive(true);
                    phoneSR.sprite = messageSprites[8];
                    Debug.Log("Done");
                    once = false;
                    break;
                }
                else
                {
                    consequences.text = "Your relationship with this character has weakened...";
                    switchWorld();
                    disableAllButtons();
                    dialogueText.text = "";
                    phoneObj.SetActive(false);
                    textBox.SetActive(false);
                    Time.timeScale = 1;
                    continueButt.gameObject.SetActive(false);
                    once = true;
                    Debug.Log(once);
                    break;
                }
            case 30:
                if (once)
                {
                    disableAllButtons();
                    dialogueText.text = "";
                    continueButt.gameObject.SetActive(true);
                    phoneSR.sprite = messageSprites[10];
                    Debug.Log("Done");
                    once = false;
                    break;
                }
                else
                {
                    consequences.text = "Your relationship with this character has weakened...";
                    switchWorld();
                    disableAllButtons();
                    dialogueText.text = "";
                    phoneObj.SetActive(false);
                    textBox.SetActive(false);
                    Time.timeScale = 1;
                    continueButt.gameObject.SetActive(false);
                    once = true;
                    Debug.Log(once);
                    break;
                }
            case 31:
                disableAllButtons();
                dialogueText.text = "";
                continueButt.gameObject.SetActive(false);
                phoneObj.SetActive(true);
                phoneSR.sprite = messageSprites[11];
                // toID32 (30) and toID33 (31)
                toIDbuttons[30].gameObject.SetActive(true);
                toIDbuttons[31].gameObject.SetActive(true);
                break;
            case 32:
                if (once)
                {
                    disableAllButtons();
                    dialogueText.text = "";
                    continueButt.gameObject.SetActive(true);
                    phoneSR.sprite = messageSprites[12];
                    Debug.Log("Done");
                    once = false;
                    break;
                }
                else
                {
                    disableAllButtons();
                    dialogueText.text = "";
                    phoneObj.SetActive(false);
                    textBox.SetActive(false);
                    Time.timeScale = 1;
                    continueButt.gameObject.SetActive(false);
                    once = true;
                    Debug.Log(once);
                    break;
                }
            case 33:
                if (once)
                {
                    disableAllButtons();
                    dialogueText.text = "";
                    continueButt.gameObject.SetActive(true);
                    phoneSR.sprite = messageSprites[13];
                    Debug.Log("Done");
                    once = false;
                    break;
                }
                else
                {
                    consequences.text = "Your relationship with this character has weakened...";
                    switchWorld();
                    disableAllButtons();
                    dialogueText.text = "";
                    phoneObj.SetActive(false);
                    textBox.SetActive(false);
                    Time.timeScale = 1;
                    continueButt.gameObject.SetActive(false);
                    once = true;
                    Debug.Log(once);
                    break;
                }

            default:
                disableAllButtons();
                dialogueText.text = "";
                phoneObj.SetActive(false);
                textBox.SetActive(false);
                Time.timeScale = 1;
                continueButt.gameObject.SetActive(false);
                break;
        }
    }

    void switchWorld()
    {
        StartCoroutine(StartCountdown());
        /* if (envSR.color == Color.white)
        {
            //Debug.Log("White, change to grey");
            envSR.color = Color.gray;
        } else
        {
            //Debug.Log("Grey, change to white");
            //environment.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
            envSR.color = Color.white;
        }
        */

        if (envSR.sprite.name == "grass")
        {
            //Debug.Log("White, change to grey");
            envSR.sprite = greyGrass;
        }
        /*else
        {
            //Debug.Log("Grey, change to white");
            //environment.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
            envSR.sprite = grass;
        }
        */
    }

    public IEnumerator StartCountdown(float countdownValue = 5)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }
        consequences.text = "";
    }

}
