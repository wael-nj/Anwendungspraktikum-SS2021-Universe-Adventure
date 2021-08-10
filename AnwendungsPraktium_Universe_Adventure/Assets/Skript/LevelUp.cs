using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class LevelUp : MonoBehaviour
{
 
    /*
        Diese Klasse wird verwendet, um die Stufe des Spielers zu erhöhen
        und auf den LevelUp-Text anzeigen  

    */
    int levelUpPlayer =1;
    public Text level;
    void Start()
    {
        level = GetComponent<Text>();
        level.text ="1";
    }

    /*
           Alle 10000 Punkte wird das Level auf 1 erhöht und in LevelText geschrieben
    */

    public void levelUpChange(int socre){

        if(socre % 10000 == 0){
            levelUpPlayer++;
            level.text=levelUpPlayer.ToString();
        }
    }
}
