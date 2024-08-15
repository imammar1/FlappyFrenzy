using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenScript : MonoBehaviour
{
    public LogicScript logicScript; // Reference to the LogicScript
    public GameObject startScreen; // Reference to the Start Screen

    public void StartGame()
    {
        if (logicScript != null)
        {
            logicScript.StartGame(); // Call the method in LogicScript
        }
        else
        {
            Debug.LogError("LogicScript reference is not assigned.");
        }
    }
}