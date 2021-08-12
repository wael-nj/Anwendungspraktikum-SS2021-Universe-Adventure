using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Life : MonoBehaviour
{
    Handler handler;

    /*
        maxLife      Amfangsleben

        currentLife  Aktuelles Leben

        bar          Bild, das das Leben darstellt
     */

    [SerializeField] float maxLife = 1000;
    [SerializeField] float currentLife = 0;
    [SerializeField] Image bar;


    /*
       

       der Wert von currentLife bestimmen

        
    */
    void Start()
    {
        handler = FindObjectOfType<Handler>();
        currentLife = maxLife;
        
    }

     /*
       

      currentLife wird reduziert, wenn der Spieler angegriffen wird.
      Und der Wert des Lebens wird reduziert, wird das dargestelltes Balkenbild entsprechend nach rechts gezogen.
      Wenn der Wert 0 ist, wird der Spieler sterben und die GameOver-Szene geladen.

        
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
         Die Füllung des Balkenbilds wird reduziert.
    */
    void lifeBar()
    {
        bar.fillAmount = currentLife / maxLife;
    }
}
