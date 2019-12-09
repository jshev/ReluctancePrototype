using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HBController : MonoBehaviour
{
    //combatManager CM;

    public GameObject enemyHealthBar;
    public GameObject playerHealthBar;
    float initialXScale;

    public int totalHealth = 50;


    // Start is called before the first frame update
    void Start()
    {
        //CM = FindObjectOfType<combatManager>();

        // i've already altered the x scale in the editor, so I need to get what that is
        initialXScale = enemyHealthBar.transform.localScale.x;

        // reset it to zero so there is no red bar initially
        /* enemyHealthBar.transform.localScale = new Vector2(0, enemyHealthBar.transform.localScale.y);
        playerHealthBar.transform.localScale = new Vector2(0, playerHealthBar.transform.localScale.y); */

    }

    public void updateEnemyHealthBar(int currentHealth)
    {
        // calculate percentage done (a number between 0 and 1)
        float pecentDone = currentHealth * 1.0f / totalHealth;

        // multiply the percentage by the original scale (of what the bar looks like full)
        enemyHealthBar.transform.localScale = new Vector2(pecentDone * initialXScale, enemyHealthBar.transform.localScale.y);
    }

    public void updatePlayerHealthBar(int currentHealth)
    {
        // calculate percentage done (a number between 0 and 1)
        float pecentDone = currentHealth * 1.0f / totalHealth;

        // multiply the percentage by the original scale (of what the bar looks like full)
        playerHealthBar.transform.localScale = new Vector2(pecentDone * initialXScale, playerHealthBar.transform.localScale.y);
    }
}
