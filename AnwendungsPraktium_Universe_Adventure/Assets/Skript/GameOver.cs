using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    /*
       Dieses Skript funktioniert wie das Skript Button-Handler, um Spielszene für den Spieler zu laden.
       wenn er die Restar-Button drückt oder wenn er das Spiel beenden möchte, wenn er die Exit-Button drückt

     */
    public void Restart()
    {

        int mainGameScene = SceneManager.GetActiveScene().buildIndex - 1;
        SceneManager.LoadScene(mainGameScene);

    }

    public void exitGame()
    {

        Application.Quit();
    }

}
