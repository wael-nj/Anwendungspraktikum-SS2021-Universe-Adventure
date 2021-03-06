using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Handler : MonoBehaviour
{

    /*

     Kollisionen zwischen Spielern und Feinden 
     
     Wenn der Spieler-Box-Collider mit dem Feind-Box-Collider in Kollision geht.

     playerDeath    Exploison-Effekt

     load         Zeit, um die nächste Senze zu laden
    */

    [SerializeField] ParticleSystem playerDeath;
    [SerializeField] float load = 1f;

    /*
       Methode zur Erkennung der Kollisionen zwischen dem Spieler und dem Gegner,
       hier wird das GameObject des Spielers getriggiert.

    */
    void OnTriggerEnter(Collider other)
    {

        PlayerDie();

    }

    /*
        > wenn der Spieler tödlich ist, wird der Todeseffekt ausgelöst 
        > der MeshRender des Spielers wird ausgeschaltet, so dass der MeshRender des Spielers nicht mehr angezeigt wird
        > die Bewegung des Spielers wird ausgeschaltet, so dass der Benutzer das Raumschiff nicht mehr bewegen kann
        > der BoxColider des Spielers wird ausgeschaltet
        > Am Ende wird die nächste Szene geladen

    */
   public  void PlayerDie()
    {
        playerDeath.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<PlayerMovment>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        Invoke("ReloadSceneLevel", load);
    }

    /*
        lade den GameOver Szene

    */
    void ReloadSceneLevel()
    {


        int currentSceneIndex = 2;
        SceneManager.LoadScene(currentSceneIndex);

    }

  

}
