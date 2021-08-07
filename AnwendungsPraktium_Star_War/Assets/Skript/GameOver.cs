using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    /*
       Dieses Skript lädt die Spielszene für den Spieler, 
       wenn er die Restarttaste drückt oder wenn er das Spiel beenden möchte, wenn er die Exittaste drückt

     */
    public void Restart()
    {

        /* 
                MainMeauszene hat die Index 0
                MainGameszene hat die Index 1
                GameOverszene hat die Inex 2 


                Wird die aktulle Szene  den Index - 1 geholt dann auf den Bildschirm geladen 
                damit wir den Spieleszene nochmal aud den Bildschrim laden  
           */
        int mainGameScene = SceneManager.GetActiveScene().buildIndex - 1;
        SceneManager.LoadScene(mainGameScene);

    }
    /* 
            Game Beenden


       */

    public void exitGame()
    {

        Application.Quit();
    }

}
