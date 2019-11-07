using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class combatManager : MonoBehaviour
{
    public Text enemyHtext;
    public Text playerHtext;
    public Text enemyTxt;
    public Text playerTxt;

    int enemyHealth;
    int playerHealth;

    int turnsUntilEattack;
    int turnsUntilPhealth;
    bool resting;
    bool charging;
    bool isolated;

    // Start is called before the first frame update
    void Start()
    {

        playerHealth = PlayerPrefs.GetInt("playerhealth");
        playerHealth = 50;
        enemyHealth = 50;
        resting = false;
        charging = false;
        isolated = false;
        playerHtext.text = "Player Health: " + playerHealth + "/50"; 
        enemyHtext.text = "Enemy Health: " + enemyHealth + "/50";

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0 || playerHealth <= 0)
        {
            PlayerPrefs.SetInt("playerhealth", playerHealth);
            SceneManager.LoadScene("Demo");
        }
    }

    void attackPlayer()
    {
        if (!charging)
        {
            if (Random.value > 0.5)
            //if (0.4 > 0.5)
            {
                if (!isolated)
                {
                    enemyTxt.text = "Enemy used Laugh Attack! It does 5 Damage!";
                    laughAttack();
                } else
                {
                    enemyTxt.text = "Enemy used Laugh Attack! But it does no Damage!";
                    isolated = false;
                }
            }
            else
            {
                charging = true;
                turnsUntilEattack = 1;
                //Debug.Log("Enemy started charging Eye Attack...");
                enemyTxt.text = "Enemy started charging Eye Attack...";
                //Debug.Log("turnsUntilEattack = " + turnsUntilEattack);

            }
        }
        else
        {
            eyeAttack();
        }
    }

    void eyeAttack()
    {
        if (turnsUntilEattack > 0)
        {
            turnsUntilEattack -= 1;
            //Debug.Log("Enemy is charging Eye Attack...");
            enemyTxt.text = "Enemy is charging Eye Attack...";
            //Debug.Log("turnsUntilEattack = " + turnsUntilEattack);
        }
        else
        {
            if (!isolated)
            {
                //Debug.Log("Enemy used Eye Attack!");
                enemyTxt.text = "Enemy used Eye Attack! It does 20 Damage!";
                playerHealth -= 20;
                playerHtext.text = "Player Health: " + playerHealth + "/50";
                charging = false;
            } else
            {
                enemyTxt.text = "Enemy used Eye Attack! But it does no Damage!";
                //playerHealth -= 20;
                //playerHtext.text = "Player Health: " + playerHealth + "/50";
                charging = false;
                isolated = false;
            }
            
        }
    }

    void laughAttack()
    {
        playerHealth -= 5;
        playerHtext.text = "Player Health: " + playerHealth + "/50";
    }







    public void screamButton()
    {
        if (!resting)
        {
            //Debug.Log("Andrew used Scream!");
            playerTxt.text = "Andrew used Scream! It does 5 Damage!";
            enemyHealth -= 5;
            enemyHtext.text = "Enemy Health: " + enemyHealth + "/50";
            attackPlayer();
        } else
        {
            //Debug.Log("Andrew is Resting...");
            playerTxt.text = "Andrew is Resting...";
            Debug.Log("turnsUntilPhealth = " + turnsUntilPhealth);
            rest();
            attackPlayer();
        }
    }

    public void lastOutButton()
    {
        if (!resting)
        {
            //Debug.Log("Andrew used Lash Out!");
            playerTxt.text = "Andrew used Lash Out! It does 10 Damage!";
            enemyHealth -= 10;
            enemyHtext.text = "Enemy Health: " + enemyHealth + "/50";
            attackPlayer();
        }
        else
        {
            //Debug.Log("Andrew is Resting...");
            playerTxt.text = "Andrew is Resting...";
            Debug.Log("turnsUntilPhealth = " + turnsUntilPhealth);
            rest();
            attackPlayer();
        }
    }

    public void isolateButton()
    {
        if (!resting)
        {
            //Debug.Log("Andrew used Self Isloate! His defense was increased by 1!");
            //Debug.Log("Andrew used Self Isloate! He takes no Damage this Turn!");
            playerTxt.text = "Andrew used Self Isloate! He takes no Damage this Turn!";
            isolated = true;
            attackPlayer();
        }
        else
        {
            //Debug.Log("Andrew is Resting...");
            playerTxt.text = "Andrew is Resting...";
            Debug.Log("turnsUntilPhealth = " + turnsUntilPhealth);
            rest();
            attackPlayer();
        }
    }

    public void restButton()
    {
        if (!resting)
        {
            resting = true;
            turnsUntilPhealth = 1;
            //Debug.Log("Andrew has started Resting...");
            playerTxt.text = "Andrew has started Resting...";
            Debug.Log("turnsUntilPhealth = " + turnsUntilPhealth);
            attackPlayer();
        }
        else
        {
            //Debug.Log("Andrew is Resting...");
            playerTxt.text = "Andrew is Resting...";
            Debug.Log("turnsUntilPhealth = " + turnsUntilPhealth);
            rest();
            attackPlayer();
        }
    }

    void rest()
    {
        if (turnsUntilPhealth > 0)
        {
            turnsUntilPhealth -= 1;
            //Debug.Log("turnsUntilPhealth = " + turnsUntilPhealth);
        }
        else
        {
            //Debug.Log("Andrew is Rested!");
            playerTxt.text = "Andrew is Rested! He gains 15 HP!";
            playerHealth += 15;
            playerHtext.text = "Player Health: " + playerHealth + "/50";
            resting = false;
        }
    }
}
