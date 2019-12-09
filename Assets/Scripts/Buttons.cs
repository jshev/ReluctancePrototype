using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        PlayerPrefs.SetString("leaveArea", "false");
        PlayerPrefs.SetInt("BFRIENDSHIP", 8);
        PlayerPrefs.SetInt("SFRIENDSHIP", 8);
        PlayerPrefs.SetInt("ANXIETY", 7);
        PlayerPrefs.SetInt("DEPRESSION", 7);
        SceneManager.LoadScene("DormRoom");
    }
}
