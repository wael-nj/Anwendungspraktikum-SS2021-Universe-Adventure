using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    /*
      Dieses Skript lädt die Spielszene für den Spieler, 
      wenn er die Start-Button drückt oder wenn er das Spiel beenden möchte, wenn er die Exit-Button drückt

    */
    public void playGame()
    {

        /* 
             MainMeauszene hat die Index 0
             MainGameszene hat die Index 1
             GameOverszene hat die Inex 2 


             hier wird die aktulle Szene + 1 auf den Bildschirm geladen  
        */
        int mainGameScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(mainGameScene);

    }

    /* 
      Sobald Exit-Button gedrückt wird, wird die Funktion exitGame() aufgerufen, um das Spiel zu beenden.


   */
    public void exitGame()
    {

        Application.Quit();
    }

}
