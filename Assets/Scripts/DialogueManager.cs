using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    levelChanger lvlC;
    public GameObject sab;
    public GameObject bo;

    public Text dialogueText;
    public Text friendCon;
    public Text illnessCon;

    public GameObject environment;
    SpriteRenderer envSR;
    float currCountdownValue;

    public GameObject friendPort;
    SpriteRenderer friendSR;
    public Sprite botanSprite;
    public Sprite sabrinaSprite;
    public Sprite professorSprite;

    public GameObject textBox;
    public Button continueButt;
    public GameObject phoneObj;
    public Sprite greyGrass;
    public Sprite grass;
    public GameObject midTcol;
    public GameObject corTcol;
    public GameObject introBox;
    public GameObject creeper;
    public GameObject SabrinaIsAnAngel;
    SpriteRenderer phoneSR;
    public Dialogue dig;
    int tempBFRIENDSHIP;
    int tempSFRIENDSHIP;
    int tempANXIETY;
    int tempDEPRESSION;

    public Button[] toIDbuttons;
    // toID2 (0), toID3 (1), toID4 (2), toID5 (3), toID6 (4), toID8 (5), toID9 (6), toID10 (7), toID11 (8), toID12 (9)
    // toID13 (10), toID14 (11), toID15 (12), toID17 (13), toID18 (14), toID21 (15), toID25 (16), toID26 (17), toID27 (18)
    // toID29 (19), toID30 (20), toID31 (21), toID32 (22), toID33 (23), toID34 (24), toID35 (25), toID36 (26), toID37 (27)
    // toID38 (28), toID39 (29), toID40 (30), toID41 (31), toID42 (32), toID43 (33), toID44 (34), toID45 (35), toID46 (36)

    // School toIDbuttons...
    // toID48 (0), toID49 (1), toID50 (2), toID51 (3), toID52 (4)

    public Sprite[] messageSprites;
    // 4 Botan, 1 Sabrina

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
        friendSR = friendPort.GetComponent<SpriteRenderer>();
        phoneSR = phoneObj.GetComponent<SpriteRenderer>();
        phoneObj.SetActive(false);
        PlayerPrefs.SetString("leaveArea", "false");

        tempBFRIENDSHIP = PlayerPrefs.GetInt("BFRIENDSHIP");
        tempSFRIENDSHIP = PlayerPrefs.GetInt("SFRIENDSHIP");
        tempANXIETY = PlayerPrefs.GetInt("ANXIETY");
        tempDEPRESSION = PlayerPrefs.GetInt("DEPRESSION");

        lvlC = FindObjectOfType<levelChanger>();
    }

	public void StartDialogue(Dialogue dialogue)
	{
        phoneObj.SetActive(false);
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
            case 1:
                disableAllButtons();
                continueButt.gameObject.SetActive(false);
                // toID2
                toIDbuttons[0].gameObject.SetActive(true);
                break;
            case 2:
                disableAllButtons();
                dialogueText.text = "";
                continueButt.gameObject.SetActive(false);
                phoneObj.SetActive(true);
                phoneSR.sprite = messageSprites[0];
                friendSR.sprite = null;
                // toID3 and to ID4
                toIDbuttons[1].gameObject.SetActive(true);
                toIDbuttons[2].gameObject.SetActive(true);
                break;
            case 3:
                disableAllButtons();
                dialogueText.text = "";
                continueButt.gameObject.SetActive(false);
                phoneObj.SetActive(true);
                phoneSR.sprite = messageSprites[1];
                friendSR.sprite = null;
                // toID5
                toIDbuttons[3].gameObject.SetActive(true);
                break;
            case 4:
                disableAllButtons();
                dialogueText.text = "";
                continueButt.gameObject.SetActive(false);
                phoneObj.SetActive(true);
                phoneSR.sprite = messageSprites[2];
                friendSR.sprite = null;
                // toID5
                toIDbuttons[3].gameObject.SetActive(true);
                break;
            case 5:
                disableAllButtons();
                dialogueText.text = "";
                continueButt.gameObject.SetActive(false);
                phoneObj.SetActive(true);
                phoneSR.sprite = messageSprites[3];
                friendSR.sprite = null;
                // toID6
                toIDbuttons[4].gameObject.SetActive(true);
                PlayerPrefs.SetString("leaveArea", "true");
                break;


            case 7:
                disableAllButtons();
                continueButt.gameObject.SetActive(false);
                friendSR.sprite = botanSprite;
                // toID8 and toID9
                toIDbuttons[5].gameObject.SetActive(true);
                toIDbuttons[6].gameObject.SetActive(true);
                break;
            case 8:
                disableAllButtons();
                continueButt.gameObject.SetActive(false);
                friendSR.sprite = botanSprite;
                PlayerPrefs.SetInt("BFRIENDSHIP", (PlayerPrefs.GetInt("BFRIENDSHIP") - 1));
                // toID10 and toID11
                toIDbuttons[7].gameObject.SetActive(true);
                toIDbuttons[8].gameObject.SetActive(true);
                break;
            case 9:
                disableAllButtons();
                continueButt.gameObject.SetActive(false);
                friendSR.sprite = botanSprite;
                // toID8 and toID12
                toIDbuttons[5].gameObject.SetActive(true);
                toIDbuttons[9].gameObject.SetActive(true);
                break;
            case 10:
                disableAllButtons();
                continueButt.gameObject.SetActive(false);
                friendSR.sprite = botanSprite;
                PlayerPrefs.SetInt("BFRIENDSHIP", (PlayerPrefs.GetInt("BFRIENDSHIP") + 1));
                PlayerPrefs.SetInt("ANXIETY", (PlayerPrefs.GetInt("ANXIETY") - 1));
                PlayerPrefs.SetInt("DEPRESSION", (PlayerPrefs.GetInt("DEPRESSION") - 1));
                // toID13 and toID14
                toIDbuttons[10].gameObject.SetActive(true);
                toIDbuttons[11].gameObject.SetActive(true);
                break;
            case 11:
                disableAllButtons();
                continueButt.gameObject.SetActive(false);
                friendSR.sprite = botanSprite;
                PlayerPrefs.SetInt("BFRIENDSHIP", (PlayerPrefs.GetInt("BFRIENDSHIP") - 1));
                PlayerPrefs.SetInt("ANXIETY", (PlayerPrefs.GetInt("ANXIETY") + 1));
                // toID13 and toID14
                toIDbuttons[10].gameObject.SetActive(true);
                toIDbuttons[11].gameObject.SetActive(true);
                break;
            case 12:
                disableAllButtons();
                continueButt.gameObject.SetActive(false);
                friendSR.sprite = botanSprite;
                PlayerPrefs.SetInt("BFRIENDSHIP", (PlayerPrefs.GetInt("BFRIENDSHIP") - 1));
                // toID10 and toID11
                toIDbuttons[7].gameObject.SetActive(true);
                toIDbuttons[8].gameObject.SetActive(true);
                break;
            case 13:
                //SceneManager.LoadScene("Combat");
                disableAllButtons();
                dialogueText.text = "";
                phoneObj.SetActive(false);
                textBox.SetActive(false);
                Time.timeScale = 1;
                continueButt.gameObject.SetActive(false);
                displayConsequence();
                StartCoroutine(StartCountdown());

                Debug.Log(PlayerPrefs.GetInt("BFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("SFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("ANXIETY"));
                Debug.Log(PlayerPrefs.GetInt("DEPRESSION"));

                PlayerPrefs.SetString("leaveArea", "true");
            break;
            case 14:
                disableAllButtons();
                dialogueText.text = "";
                continueButt.gameObject.SetActive(false);
                phoneObj.SetActive(true);
                phoneSR.sprite = messageSprites[4];
                friendSR.sprite = botanSprite;
                // toID15
                toIDbuttons[12].gameObject.SetActive(true);
                break;
            case 15:
                //SceneManager.LoadScene("Combat");
                disableAllButtons();
                dialogueText.text = "";
                phoneObj.SetActive(false);
                textBox.SetActive(false);
                Time.timeScale = 1;
                continueButt.gameObject.SetActive(false);
                displayConsequence();
                StartCoroutine(StartCountdown());

                Debug.Log(PlayerPrefs.GetInt("BFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("SFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("ANXIETY"));
                Debug.Log(PlayerPrefs.GetInt("DEPRESSION"));

                PlayerPrefs.SetString("leaveArea", "true");
            break;
            case 16:
                continueButt.gameObject.SetActive(false);
                disableAllButtons();
                friendSR.sprite = botanSprite;
                // toID17 and toID18
                toIDbuttons[13].gameObject.SetActive(true);
                toIDbuttons[14].gameObject.SetActive(true);
                break;
            case 17:
                /*
                 * ADD BOTAN GETTING FOOD ANIMATION HERE
                 * start at entrance and end at corner table
                 */
                corTcol.SetActive(true);
                friendSR.sprite = null;
                disableAllButtons();
                dialogueText.text = "";
                phoneObj.SetActive(false);
                textBox.SetActive(false);
                Time.timeScale = 1;
                continueButt.gameObject.SetActive(false);
                displayConsequence();
                StartCoroutine(StartCountdown());

                Debug.Log(PlayerPrefs.GetInt("BFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("SFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("ANXIETY"));
                Debug.Log(PlayerPrefs.GetInt("DEPRESSION"));
                
                break;
            case 18:
                /*
                 * ADD BOTAN GETTING FOOD ANIMATION HERE
                 * start at entrance and end at middle table
                 */
                midTcol.SetActive(true);
                friendSR.sprite = null;
                disableAllButtons();
                dialogueText.text = "";
                phoneObj.SetActive(false);
                textBox.SetActive(false);
                Time.timeScale = 1;
                continueButt.gameObject.SetActive(false);
                displayConsequence();
                StartCoroutine(StartCountdown());

                Debug.Log(PlayerPrefs.GetInt("BFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("SFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("ANXIETY"));
                Debug.Log(PlayerPrefs.GetInt("DEPRESSION"));

                break;
            case 19:
                continueButt.gameObject.SetActive(false);
                disableAllButtons();
                //friendSR.sprite = botanSprite;
                PlayerPrefs.SetInt("ANXIETY", (PlayerPrefs.GetInt("ANXIETY") + 1));
                // toID21
                toIDbuttons[15].gameObject.SetActive(true);
                break;
            case 20:
                continueButt.gameObject.SetActive(false);
                disableAllButtons();
                //friendSR.sprite = botanSprite;
                PlayerPrefs.SetInt("ANXIETY", (PlayerPrefs.GetInt("ANXIETY") - 1));
                // toID21
                toIDbuttons[15].gameObject.SetActive(true);
                break;

            case 21:
                disableAllButtons();
                dialogueText.text = "";
                phoneObj.SetActive(false);
                textBox.SetActive(false);
                Time.timeScale = 1;
                continueButt.gameObject.SetActive(false);
                displayConsequence();
                StartCoroutine(StartCountdown());
                int anxiety = PlayerPrefs.GetInt("ANXIETY");
                if (anxiety > tempANXIETY)
                {
                    lvlC.FadeToLevel("CafeM2");
                } else
                {
                    lvlC.FadeToLevel("CafeC2");
                }

                Debug.Log(PlayerPrefs.GetInt("BFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("SFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("ANXIETY"));
                Debug.Log(PlayerPrefs.GetInt("DEPRESSION"));
                break;
            case 22:
                introBox.SetActive(false);
                friendSR.sprite = null;

                disableAllButtons();
                dialogueText.text = "";
                phoneObj.SetActive(false);
                textBox.SetActive(false);
                Time.timeScale = 1;
                continueButt.gameObject.SetActive(false);
                displayConsequence();
                StartCoroutine(StartCountdown());

                Debug.Log(PlayerPrefs.GetInt("BFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("SFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("ANXIETY"));
                Debug.Log(PlayerPrefs.GetInt("DEPRESSION"));
                break;
            case 23:
                SabrinaIsAnAngel.SetActive(false);
                friendSR.sprite = sabrinaSprite;

                disableAllButtons();
                dialogueText.text = "";
                phoneObj.SetActive(false);
                textBox.SetActive(false);
                Time.timeScale = 1;
                continueButt.gameObject.SetActive(false);
                displayConsequence();
                StartCoroutine(StartCountdown());

                Debug.Log(PlayerPrefs.GetInt("BFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("SFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("ANXIETY"));
                Debug.Log(PlayerPrefs.GetInt("DEPRESSION"));
                break;
            case 24:
                continueButt.gameObject.SetActive(false);
                disableAllButtons();
                friendSR.sprite = sabrinaSprite;
                // toID25 and toID26
                toIDbuttons[16].gameObject.SetActive(true);
                toIDbuttons[17].gameObject.SetActive(true);
                break;
            case 25:
                continueButt.gameObject.SetActive(false);
                disableAllButtons();
                friendSR.sprite = sabrinaSprite;
                // toID26 and toID27
                toIDbuttons[18].gameObject.SetActive(true);
                toIDbuttons[17].gameObject.SetActive(true);
                break;
            case 26:
                disableAllButtons();
                dialogueText.text = "";
                phoneObj.SetActive(false);
                textBox.SetActive(false);
                Time.timeScale = 1;
                continueButt.gameObject.SetActive(false);
                displayConsequence();
                StartCoroutine(StartCountdown());
                if (SceneManager.GetActiveScene().name == "CafeM2")
                {
                    lvlC.FadeToLevel("CafeM3");
                    //lvlC.FadeToLevel("Menu");
                }
                else
                {
                    lvlC.FadeToLevel("CafeC3");
                    //lvlC.FadeToLevel("TBC");
                }

                Debug.Log(PlayerPrefs.GetInt("BFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("SFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("ANXIETY"));
                Debug.Log(PlayerPrefs.GetInt("DEPRESSION"));
                break;
            case 27:
                disableAllButtons();
                dialogueText.text = "";
                phoneObj.SetActive(false);
                textBox.SetActive(false);
                Time.timeScale = 1;
                continueButt.gameObject.SetActive(false);
                PlayerPrefs.SetInt("ANXIETY", (PlayerPrefs.GetInt("ANXIETY") + 1));
                displayConsequence();
                StartCoroutine(StartCountdown());
                if (SceneManager.GetActiveScene().name == "CafeM2")
                {
                    lvlC.FadeToLevel("CafeM3");
                    //lvlC.FadeToLevel("Menu");
                }
                else
                {
                    lvlC.FadeToLevel("CafeC3");
                    //lvlC.FadeToLevel("TBC");
                }

                Debug.Log(PlayerPrefs.GetInt("BFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("SFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("ANXIETY"));
                Debug.Log(PlayerPrefs.GetInt("DEPRESSION"));
                break;
            case 28:
                continueButt.gameObject.SetActive(false);
                disableAllButtons();
                friendSR.sprite = sabrinaSprite;
                introBox.SetActive(false);

                // toID29, toID30, and toID31
                toIDbuttons[19].gameObject.SetActive(true);
                //toIDbuttons[20].gameObject.SetActive(true);
                //toIDbuttons[21].gameObject.SetActive(true);
                break;
            case 29:
                continueButt.gameObject.SetActive(false);
                disableAllButtons();
                friendSR.sprite = sabrinaSprite;
                // toID32 and toID33
                toIDbuttons[22].gameObject.SetActive(true);
                //toIDbuttons[23].gameObject.SetActive(true);
                break;

            case 32:
                continueButt.gameObject.SetActive(false);
                disableAllButtons();
                friendSR.sprite = botanSprite;
                PlayerPrefs.SetString("BOTANKNOWS", "false");
                PlayerPrefs.SetInt("SFRIENDSHIP", (PlayerPrefs.GetInt("SFRIENDSHIP") - 1));
                PlayerPrefs.SetInt("ANXIETY", (PlayerPrefs.GetInt("ANXIETY") + 1));
                // toID34 and toID35
                toIDbuttons[24].gameObject.SetActive(true);
                //toIDbuttons[25].gameObject.SetActive(true);
                break;
            case 33:
                continueButt.gameObject.SetActive(false);
                disableAllButtons();
                friendSR.sprite = sabrinaSprite;
                PlayerPrefs.SetInt("BFRIENDSHIP", (PlayerPrefs.GetInt("BFRIENDSHIP") - 1));
                // toID34 and toID35
                //toIDbuttons[24].gameObject.SetActive(true);
                //toIDbuttons[25].gameObject.SetActive(true);
                break;
            case 34:
                continueButt.gameObject.SetActive(false);
                disableAllButtons();
                friendSR.sprite = botanSprite;
                PlayerPrefs.SetString("BOTANKNOWS", "true");
                // toID36 and toID37
                toIDbuttons[26].gameObject.SetActive(true);
                //toIDbuttons[27].gameObject.SetActive(true);
                break;


            case 36:
                continueButt.gameObject.SetActive(false);
                disableAllButtons();
                friendSR.sprite = sabrinaSprite;
                PlayerPrefs.SetInt("SFRIENDSHIP", (PlayerPrefs.GetInt("SFRIENDSHIP") - 1));
                PlayerPrefs.SetInt("ANXIETY", (PlayerPrefs.GetInt("ANXIETY") + 1));
                // toID38 and toID39
                toIDbuttons[28].gameObject.SetActive(true);
                //toIDbuttons[29].gameObject.SetActive(true);
                break;

            case 38:
                continueButt.gameObject.SetActive(false);
                disableAllButtons();
                friendSR.sprite = sabrinaSprite;
                PlayerPrefs.SetInt("SFRIENDSHIP", (PlayerPrefs.GetInt("SFRIENDSHIP") - 1));
                // toID40 and toID41
                toIDbuttons[30].gameObject.SetActive(true);
                toIDbuttons[31].gameObject.SetActive(true);
                break;

            case 40:
                continueButt.gameObject.SetActive(false);
                disableAllButtons();
                friendSR.sprite = botanSprite;
                sab.SetActive(false);
                PlayerPrefs.SetInt("SFRIENDSHIP", (PlayerPrefs.GetInt("SFRIENDSHIP") - 3));
                PlayerPrefs.SetInt("ANXIETY", (PlayerPrefs.GetInt("ANXIETY") + 2));
                PlayerPrefs.SetInt("DEPRESSION", (PlayerPrefs.GetInt("DEPRESSION") + 1));
                // toID42 and toID43
                toIDbuttons[32].gameObject.SetActive(true);
                toIDbuttons[33].gameObject.SetActive(true);
                break;
            case 41:
                continueButt.gameObject.SetActive(false);
                disableAllButtons();
                friendSR.sprite = botanSprite;
                PlayerPrefs.SetInt("SFRIENDSHIP", (PlayerPrefs.GetInt("SFRIENDSHIP") - 3));
                PlayerPrefs.SetInt("ANXIETY", (PlayerPrefs.GetInt("ANXIETY") + 2));
                PlayerPrefs.SetInt("DEPRESSION", (PlayerPrefs.GetInt("DEPRESSION") + 1));
                // toID42 and toID43
                toIDbuttons[32].gameObject.SetActive(true);
                toIDbuttons[33].gameObject.SetActive(true);
                break;
            case 42:
                continueButt.gameObject.SetActive(false);
                disableAllButtons();
                friendSR.sprite = botanSprite;
                // toID44 and toID45
                toIDbuttons[34].gameObject.SetActive(true);
                toIDbuttons[35].gameObject.SetActive(true);
                break;
            case 43:
                continueButt.gameObject.SetActive(false);
                disableAllButtons();
                friendSR.sprite = botanSprite;
                // toID44 and toID45
                toIDbuttons[34].gameObject.SetActive(true);
                toIDbuttons[35].gameObject.SetActive(true);
                break;
            case 44:
                bo.SetActive(false);
                disableAllButtons();
                dialogueText.text = "";
                phoneObj.SetActive(false);
                textBox.SetActive(false);
                Time.timeScale = 1;
                continueButt.gameObject.SetActive(false);
                PlayerPrefs.SetInt("BFRIENDSHIP", (PlayerPrefs.GetInt("BFRIENDSHIP") - 2));
                PlayerPrefs.SetInt("ANXIETY", (PlayerPrefs.GetInt("ANXIETY") + 1));
                PlayerPrefs.SetInt("DEPRESSION", (PlayerPrefs.GetInt("DEPRESSION") + 1));
                displayConsequence();
                StartCoroutine(StartCountdown());

                Debug.Log(PlayerPrefs.GetInt("BFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("SFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("ANXIETY"));
                Debug.Log(PlayerPrefs.GetInt("DEPRESSION"));
                break;
            case 45:
                continueButt.gameObject.SetActive(false);
                disableAllButtons();
                friendSR.sprite = botanSprite;
                PlayerPrefs.SetString("LEARNBDREAM", "true");
                // toID44 and toID46
                toIDbuttons[34].gameObject.SetActive(true);
                toIDbuttons[36].gameObject.SetActive(true);
                break;
            case 46:
                bo.SetActive(false);
                disableAllButtons();
                dialogueText.text = "";
                phoneObj.SetActive(false);
                textBox.SetActive(false);
                Time.timeScale = 1;
                continueButt.gameObject.SetActive(false);
                PlayerPrefs.SetInt("BFRIENDSHIP", (PlayerPrefs.GetInt("BFRIENDSHIP") + 1));
                PlayerPrefs.SetInt("ANXIETY", (PlayerPrefs.GetInt("ANXIETY") + 1));
                PlayerPrefs.SetInt("DEPRESSION", (PlayerPrefs.GetInt("DEPRESSION") - 1));
                displayConsequence();
                StartCoroutine(StartCountdown());

                Debug.Log(PlayerPrefs.GetInt("BFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("SFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("ANXIETY"));
                Debug.Log(PlayerPrefs.GetInt("DEPRESSION"));
                break;



            // Classroom
            case 47:
                continueButt.gameObject.SetActive(false);
                disableAllButtons();
                friendSR.sprite = professorSprite;
                // toID48 or toID49
                if (PlayerPrefs.GetInt("ANXIETY") < 8)
                //if (7 < 8)
                {
                    toIDbuttons[0].gameObject.SetActive(true);
                } else
                {
                    toIDbuttons[1].gameObject.SetActive(true);
                }
                break;
            case 48:
                continueButt.gameObject.SetActive(false);
                disableAllButtons();
                friendSR.sprite = null;
                // toID50 or toID51
                if (PlayerPrefs.GetInt("ANXIETY") < 7)
                //if (6 < 7)
                {
                    toIDbuttons[2].gameObject.SetActive(true);
                }
                else
                {
                    toIDbuttons[3].gameObject.SetActive(true);
                }
                break;
            case 49:
                // toID51 or toID52
                continueButt.gameObject.SetActive(false);
                disableAllButtons();
                friendSR.sprite = null;
                PlayerPrefs.SetInt("ANXIETY", (PlayerPrefs.GetInt("ANXIETY") + 2));
                PlayerPrefs.SetInt("DEPRESSION", (PlayerPrefs.GetInt("DEPRESSION") + 1));
                if (PlayerPrefs.GetInt("ANXIETY") < 9)
                {
                    toIDbuttons[3].gameObject.SetActive(true);
                }
                else
                {
                    toIDbuttons[4].gameObject.SetActive(true);
                }
                break;
            case 50:
                disableAllButtons();
                dialogueText.text = "";
                phoneObj.SetActive(false);
                textBox.SetActive(false);
                Time.timeScale = 1;
                continueButt.gameObject.SetActive(false);
                displayConsequence();
                StartCoroutine(StartCountdown());
                lvlC.FadeToLevel("ClassF2");

                Debug.Log(PlayerPrefs.GetInt("BFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("SFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("ANXIETY"));
                Debug.Log(PlayerPrefs.GetInt("DEPRESSION"));

                break;
            case 51:
                disableAllButtons();
                dialogueText.text = "";
                phoneObj.SetActive(false);
                textBox.SetActive(false);
                Time.timeScale = 1;
                continueButt.gameObject.SetActive(false);
                displayConsequence();
                StartCoroutine(StartCountdown());
                lvlC.FadeToLevel("ClassB2");

                Debug.Log(PlayerPrefs.GetInt("BFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("SFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("ANXIETY"));
                Debug.Log(PlayerPrefs.GetInt("DEPRESSION"));
                break;
            case 52:
                //SceneManager.LoadScene("Combat");
                disableAllButtons();
                dialogueText.text = "";
                phoneObj.SetActive(false);
                textBox.SetActive(false);
                Time.timeScale = 1;
                continueButt.gameObject.SetActive(false);
                displayConsequence();
                StartCoroutine(StartCountdown());

                Debug.Log(PlayerPrefs.GetInt("BFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("SFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("ANXIETY"));
                Debug.Log(PlayerPrefs.GetInt("DEPRESSION"));

                PlayerPrefs.SetString("exit", "dash");
                break;
            case 53:
                disableAllButtons();
                dialogueText.text = "";
                phoneObj.SetActive(false);
                textBox.SetActive(false);
                Time.timeScale = 1;
                continueButt.gameObject.SetActive(false);
                displayConsequence();
                StartCoroutine(StartCountdown());

                Debug.Log(PlayerPrefs.GetInt("BFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("SFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("ANXIETY"));
                Debug.Log(PlayerPrefs.GetInt("DEPRESSION"));

                PlayerPrefs.SetString("exit", "leave");
                introBox.SetActive(false);

                // toID29, toID30, and toID31
                //toIDbuttons[19].gameObject.SetActive(true);
                //toIDbuttons[20].gameObject.SetActive(true);
                //toIDbuttons[21].gameObject.SetActive(true);
                break;

            case 54:
                disableAllButtons();
                dialogueText.text = "";
                phoneObj.SetActive(false);
                textBox.SetActive(false);
                Time.timeScale = 1;
                continueButt.gameObject.SetActive(false);
                displayConsequence();
                StartCoroutine(StartCountdown());

                Debug.Log(PlayerPrefs.GetInt("BFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("SFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("ANXIETY"));
                Debug.Log(PlayerPrefs.GetInt("DEPRESSION"));

                PlayerPrefs.SetString("exit", "leave");
                introBox.SetActive(false);

                // toID29, toID30, and toID31
                //toIDbuttons[19].gameObject.SetActive(true);
                //toIDbuttons[20].gameObject.SetActive(true);
                //toIDbuttons[21].gameObject.SetActive(true);
                break;
            case 55:
                continueButt.gameObject.SetActive(false);
                disableAllButtons();
                // OpenUp and toID56
                toIDbuttons[5].gameObject.SetActive(true);
                toIDbuttons[6].gameObject.SetActive(true);

                introBox.SetActive(false);

                // toID29, toID30, and toID31
                //toIDbuttons[19].gameObject.SetActive(true);
                //toIDbuttons[20].gameObject.SetActive(true);
                //toIDbuttons[21].gameObject.SetActive(true);
                break;

            case 57:
                disableAllButtons();
                dialogueText.text = "";
                phoneObj.SetActive(false);
                textBox.SetActive(false);
                Time.timeScale = 1;
                continueButt.gameObject.SetActive(false);
                displayConsequence();
                creeper.SetActive(true);
                StartCoroutine(StartCountdown());

                Debug.Log(PlayerPrefs.GetInt("BFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("SFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("ANXIETY"));
                Debug.Log(PlayerPrefs.GetInt("DEPRESSION"));
                break;
            case 58:
                continueButt.gameObject.SetActive(false);
                disableAllButtons();
                // toID56
                toIDbuttons[5].gameObject.SetActive(true);

                // toID29, toID30, and toID31
                //toIDbuttons[19].gameObject.SetActive(true);
                //toIDbuttons[20].gameObject.SetActive(true);
                //toIDbuttons[21].gameObject.SetActive(true);
                break;
            case 61:
                disableAllButtons();
                dialogueText.text = "";
                phoneObj.SetActive(false);
                textBox.SetActive(false);
                Time.timeScale = 1;
                continueButt.gameObject.SetActive(false);
                displayConsequence();
                StartCoroutine(StartCountdown());
                lvlC.FadeToLevel("Combat");

                Debug.Log(PlayerPrefs.GetInt("BFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("SFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("ANXIETY"));
                Debug.Log(PlayerPrefs.GetInt("DEPRESSION"));

                break;

            /*
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
                */
            default:
                disableAllButtons();
                dialogueText.text = "";
                phoneObj.SetActive(false);
                textBox.SetActive(false);
                Time.timeScale = 1;
                continueButt.gameObject.SetActive(false);
                displayConsequence();
                StartCoroutine(StartCountdown());

                Debug.Log(PlayerPrefs.GetInt("BFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("SFRIENDSHIP"));
                Debug.Log(PlayerPrefs.GetInt("ANXIETY"));
                Debug.Log(PlayerPrefs.GetInt("DEPRESSION"));
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

        /*if (envSR.sprite.name == "grass")
        {
            //Debug.Log("White, change to grey");
            envSR.sprite = greyGrass;

        }
        else
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
            //Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }
        ///consequences.text = "";
        friendCon.text = "";
        illnessCon.text = "";
    }

    public void displayConsequence()
    {
        int bfriend = PlayerPrefs.GetInt("BFRIENDSHIP");
        int sfriend = PlayerPrefs.GetInt("SFRIENDSHIP");
        int anxiety = PlayerPrefs.GetInt("ANXIETY");
        int depression = PlayerPrefs.GetInt("DEPRESSION");

        if (bfriend < tempBFRIENDSHIP)
        {
            //friendCon.text = "Your relationship with Botan has worsened...";
            if (sfriend < tempSFRIENDSHIP)
            {
                friendCon.text = "Your relationships with Botan and Sabrina have worsened...";
            }
            if (sfriend > tempSFRIENDSHIP)
            {
                friendCon.text = "Your relationship with Botan has worsened, but your relationship with Sabrina has improved.";
            }
            if (sfriend == tempSFRIENDSHIP)
            {
                friendCon.text = "Your relationship with Botan has worsened...";
            }
        }

        if (bfriend > tempBFRIENDSHIP)
        {
            if (sfriend < tempSFRIENDSHIP)
            {
                friendCon.text = "Your relationship with Sabrina has worsened, but your relationship with Botan has improved.";
            }
            if (sfriend > tempSFRIENDSHIP)
            {
                friendCon.text = "Your relationships with Botan and Sabrina have improved!";
            }
            if (sfriend == tempSFRIENDSHIP)
            {
                friendCon.text = "Your relationship with Botan has improved!";
            }
        }
        if (bfriend == tempBFRIENDSHIP)
        {
            if (sfriend < tempSFRIENDSHIP)
            {
                friendCon.text = "Your relationship with Sabrina has worsened...";
            }
            if (sfriend > tempSFRIENDSHIP)
            {
                friendCon.text = "Your relationship with Sabrina has improved!";
            }
        }



        if (anxiety < tempANXIETY)
        {
            if (depression < tempDEPRESSION)
            {
                illnessCon.text = "Your anxiety and depression have improved!";
            }
            if (depression > tempDEPRESSION)
            {
                illnessCon.text = "Your anxiety has improved, but your depression has worsened.";
            }
            if (depression == tempDEPRESSION)
            {
                illnessCon.text = "Your anxiety has improved!";
            }
        }
        if (anxiety > tempANXIETY)
        {
            if (depression < tempDEPRESSION)
            {
                illnessCon.text = "Your depression has improved, but your anxiety has worsened.";
            }
            if (depression > tempDEPRESSION)
            {
                illnessCon.text = "Your anxiety and depression have worsened…";
            }
            if (depression == tempDEPRESSION)
            {
                illnessCon.text = "Your anxiety has worsened…";
            }
        }
        if (anxiety == tempANXIETY)
        {
            if (depression < tempDEPRESSION)
            {
                illnessCon.text = " Your depression has improved!";
            }
            if (depression > tempDEPRESSION)
            {
                illnessCon.text = "Your depression has worsened…";
            }
        }

    }

}
