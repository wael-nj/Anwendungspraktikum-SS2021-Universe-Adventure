using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    /*
        score   aktulle Punkte anzahl
        
        sText   Score Text

        level   LevelUp Text

    */
    public int score;
    LevelUp levelUp;
    public Text sText;
    public Text level;

        /*
             
             levelUp Objekte bestimmen 
             Score-Text setzen auf 0

        */

    
    void Start() 
    {
        levelUp =FindObjectOfType<LevelUp>();
        sText = GetComponent<Text>();
        sText.text ="0";

    
    }

            /*
                   die Punktzahl erhöhen und Schreiben im Score-Text , und die Punktzahl wird bei der Methode LevelupChange überprüft,
                   ob die Stufe erhöht wurde oder nicht.

            */

    public void addScore(int addScore )
    {
        score += addScore;
        sText.text =score.ToString();
        levelUp.levelUpChange(score);
    }



  
}
