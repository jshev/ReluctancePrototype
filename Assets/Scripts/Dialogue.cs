using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// code obtained from Brackley's YouTube video on How to make a Dialogue System in Unity

[System.Serializable]
public class Dialogue
{

    public int id;

    [TextArea(3, 10)]
	public string[] sentences;

}
