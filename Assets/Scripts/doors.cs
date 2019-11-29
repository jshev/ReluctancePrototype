using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doors : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (gameObject.name == "DormDoor")
            {
                Debug.Log("DormDoor");
                if (PlayerPrefs.GetString("leaveArea") == "true")
                {
                    Debug.Log("DormDoor true");
                    SceneManager.LoadScene("Hallway");
                }
            } else if (gameObject.name == "HallwayDoor") {
                Debug.Log("HallwayDoor");
                SceneManager.LoadScene("Quad1");
            } /* else if (gameObject.name == "CafeDoor") {
                Debug.Log("CafeDoor");
                SceneManager.LoadScene("Menu");
            } */
            else if (gameObject.name == "destroy")
            {
                gameObject.SetActive(false);
            }

        }
    }
}
