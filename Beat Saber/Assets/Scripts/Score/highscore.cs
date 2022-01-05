using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class highscore : MonoBehaviour
{
    private Text highscoreList; 
    // Start is called before the first frame update
    void Start()
    {
        highscoreList = GetComponent<Text>();
      
    }

    // Update is called once per frame
    void Update()
    {
        Save.load();
        String text = "";
        int i = 1;
        gameData.scores.Sort();
        gameData.scores.Reverse();
        foreach (int score in gameData.scores)
        {
            if (i <= 5)
            {
                text+= i +"  :  " + score + "\n";
                i++;
            }
            
        }

        highscoreList.text = text;
    }
}
