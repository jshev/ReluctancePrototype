using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class doors : MonoBehaviour
{

    levelChanger lvlC;

    // Start is called before the first frame update
    void Start()
    {
        lvlC = FindObjectOfType<levelChanger>();
        //Debug.Log(gameObject.name);
        //Debug.Log(PlayerPrefs.GetString("leaveArea"));
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
                    //SceneManager.LoadScene("Hallway");
                    lvlC.FadeToLevel("Hallway");
                }
            }
            else if (gameObject.name == "HallwayDoor") {
                Debug.Log("HallwayDoor");
                //SceneManager.LoadScene("Quad1");
                lvlC.FadeToLevel("Quad1");
            }
            else if (gameObject.name == "CafeDoor") {
                Debug.Log(PlayerPrefs.GetString("leaveArea"));
                if (PlayerPrefs.GetString("leaveArea") == "true")
                {
                    Debug.Log("CafeDoor");
                    //SceneManager.LoadScene("Menu");
                    lvlC.FadeToLevel("Cafe1");
                }
            }
            else if (gameObject.name == "QuadDorr")
            {
                Debug.Log("Quad zDoor.");
                lvlC.FadeToLevel("Quad2");
            }
            else if (gameObject.name == "SchoolDoor")
            {
                //Debug.Log("Hello world!");
                lvlC.FadeToLevel("School1");
            }
            else if (gameObject.name == "ClassroomDoor")
            {
                lvlC.FadeToLevel("Class1");
            }
            else if (gameObject.name == "RightWall")
            {
                if (PlayerPrefs.GetString("exit") == "dash")
                {
                    lvlC.FadeToLevel("SchoolD2");
                } else if (PlayerPrefs.GetString("exit") == "leave")
                {
                    lvlC.FadeToLevel("SchoolL2");
                }
               
            }
            else if (gameObject.name == "BathDoor")
            {
                lvlC.FadeToLevel("Bath1");
            }
            else if (gameObject.name == "destroy")
            {
                gameObject.SetActive(false);
            }

        }
    }
}
