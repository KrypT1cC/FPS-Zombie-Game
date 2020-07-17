using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Score : MonoBehaviour
{

    static int playerScore = 0;

    public GUISkin mySkin;

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public static void AddPoints(int pointValue)
    {
        playerScore += pointValue;
    }

    void OnGUI()
    {
        GUI.skin = mySkin;
        GUIStyle style1 = mySkin.customStyles[0];

        GUI.Label(new Rect(40, Screen.height - 80, 100, 60), "Score :");
        GUI.Label(new Rect(100, Screen.height - 80, 100, 60), "" + playerScore, style1);
    }
}
