using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Life : MonoBehaviour
{
    Handler handler;

    /*
        maxLife      Spieler-Leben

        currentLife  Aktulle-Leben

        bar          Bildbar,die das leben darstellt
    */

    [SerializeField] float maxLife = 1000;
    [SerializeField] float currentLife = 0;
    [SerializeField] Image bar;


    /*
       

       zum anfang currentLife  bestimmen

        
    */
    void Start()
    {
        handler = FindObjectOfType<Handler>();
        currentLife = maxLife;
        
    }

     /*
       

      currentLife wird reduziert, wenn der Spieler angegriffen wird
      und der Lebensbarwert wird reduziert
      Wenn der Wert 0 ist, wird der Spieler töd  und die GameOver-Szene wird geladen.

        
    */
    void GetHit(int gotHit)
    {
        currentLife -= gotHit;
        lifeBar();

        if (currentLife <= 0)
        {
           handler.PlayerDie();
        }

    }

    /*
         lifebar Wert wird reduziert
    */
    void lifeBar()
    {
        bar.fillAmount = currentLife / maxLife;
    }
}