using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// code obtained from Brackley's YouTube video on How to Fade Between Scenes in Unity

public class levelChanger : MonoBehaviour
{

    public Animator animator;

    //private int levelToLoad;
    private string levelToLoad;

    /* public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    } */

    public void FadeToLevel(string lvlName)
    {
        levelToLoad = lvlName;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
