using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class gameData : MonoBehaviour
{
    public static int score = 0 ;
    public static int succesion = 0;
    public static int multiplierCurrent = 1;
    public static bool multiplicatorChange = false;
    public static float maxLife = 100.0f;
    public static float life = 100.0f;
    public static int difficulty = 1;
    public static List<int> scores = new List<int>();

    public static void resetGameData()
    {
        score = 0;
        succesion = 0;
        multiplierCurrent = 0;
        

    }
}

