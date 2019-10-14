using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    float speed;
    Rigidbody2D rb;
    Vector2 defaultPos;
    public GameObject textBox;
    public Text dialogue;
    public Text pauseTxt;

    // Start is called before the first frame update
    void Start()
    {
        defaultPos = transform.localPosition;
        speed = 10f;
        rb = GetComponent<Rigidbody2D>();
        dialogue.text = "";
        pauseTxt.text = "";
        textBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(rb.position + new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime));

        /* if (Input.anyKey)
        {
            rb.MovePosition(rb.position + new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime));
            defaultPos = transform.localPosition;
        } else
        {
            transform.position = defaultPos;
        }
        */

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 0)
            {
                pauseTxt.text = "";
                Time.timeScale = 1;
            }
            else
            {
                pauseTxt.text = "PAUSED";
                Time.timeScale = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Gray")
        {
            //Debug.Log("Hello!")
            textBox.SetActive(true);
            dialogue.text = "Hello World!";
            Time.timeScale = 0;
        }
    }
}
