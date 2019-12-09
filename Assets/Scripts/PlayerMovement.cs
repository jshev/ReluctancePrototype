using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    float speed;
    Rigidbody2D rb;
    public GameObject inventory;
    public Text pauseTxt;
    public Sprite bar;
    public GameObject[] slots;
    private Animator myAnimator;

    levelChanger lvlC;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("playerhealth", 100);
        speed = 10f;
        rb = GetComponent<Rigidbody2D>();
        pauseTxt.text = "";
        inventory.SetActive(false);
        myAnimator = GetComponent<Animator>();

        lvlC = FindObjectOfType<levelChanger>();
    }

    // Update is called once per frame
    void Update()
    {
      // movement block
        rb.MovePosition(rb.position + new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime));
        //TUTORIAL FOR ANIMATION & MOVEMENT: https://www.youtube.com/watch?v=whzomFgjT50
        myAnimator.SetFloat("speed", Input.GetAxis("Horizontal")); //Gets x-axis for horizontal movement (left and right movement)
        myAnimator.SetFloat("vertical speed", Input.GetAxis("Vertical")); //Gets y-axis for vertical movement (up and down movement)
        myAnimator.SetFloat("movement speed", speed); //if the player is moving, the speed will be recorded which will trigger the animations - Antonia G.

        // end of movement block

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 0)
            {
                pauseTxt.text = "";
                //inventory.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                pauseTxt.text = "PAUSED";
                //inventory.SetActive(true);
                Time.timeScale = 0;
            }
        }

        /*if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }
        */
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Vend")
        {
            //addToInventory(bar);
        } else if (other.gameObject.tag == "Enemy")
        {
            //SceneManager.LoadScene("Combat");
            lvlC.FadeToLevel("Combat");
        }
    }

    void addToInventory(Sprite sp)
    {
        foreach (GameObject slot in slots)
        {
            if (slot.GetComponent<SpriteRenderer>().sprite.name == "square")
            {
                slot.GetComponent<SpriteRenderer>().sprite = sp;
                break;
            }
        }
    }
}
