using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    float speed;
    Rigidbody2D rb;
    public GameObject inventory;
    public Text pauseTxt;
    public Sprite bar;
    public GameObject[] slots;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        rb = GetComponent<Rigidbody2D>();
        pauseTxt.text = "";
        inventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(rb.position + new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime));

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 0)
            {
                pauseTxt.text = "";
                inventory.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                pauseTxt.text = "INVENTORY";
                inventory.SetActive(true);
                Time.timeScale = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Vend")
        {
            addToInventory(bar);
        } else if (other.gameObject.tag == "Enemy")
        {

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
