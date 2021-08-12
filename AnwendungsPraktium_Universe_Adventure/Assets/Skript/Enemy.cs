using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /*

     enemyDeathEffect   Partikeleffekt, wenn der Feind tödlich ist 
     hitEnemyEffect     Partikeleffekt, wenn der Feind erschossen wird  
     parent             damit die resultierenden Instanziate in einem GameOject kombiniert werden
     hitEnemy           wie viel Punkte für einen Schuss berechnet werden
     hitpunkte          hitEnemyLeben

    */

    [Header("EnemyEffect")]
    [SerializeField] GameObject enemyDeathEffect;
    [SerializeField] GameObject hitEnemyEffect;
    [SerializeField] Transform parent;

    [Header("Enemy Eigenschaften")]
    [SerializeField]  int hitEnemy= 50;
    [SerializeField] int hitpunkte= 100;
    Score score;

    /*
        beim Start wird das Objekt Score ausgesucht, um referenz diese Socre Objekt zu bestimmen

    */
     void Start() {
         
         score=FindObjectOfType<Score>();
    }


    /*

      

      Diese Methode wird verwendet, um eine Kollision zu erkennen, wenn der Spieler auf den Feind schießt.
      Wenn das Leben des Feindes kleiner als 1 ist, wird der Feind zerstört und Score der Spieler erhöht.


    */
    void OnParticleCollision(GameObject other) {
        
       Hit();

       if(hitpunkte < 1){

            EnemyDeath();
        }
        
        score.addScore(hitEnemy);
    }

    /*
        Das Leben des Feindes wird reduziert und der Explosion-Effekt wird angewendet 
        und die resultierenden Instanziierungen werden zu einem GameObject kombiniert

    */
    void Hit(){

        GameObject spwans = Instantiate(hitEnemyEffect, transform.position, Quaternion.identity);
        spwans.transform.parent = parent;
        hitpunkte--;
       
    }

   /*
        Der Effekt wird angewendet und die resultierenden Instanziierungen werden zu einem GameObject kombiniert
        und der Feind zerstört wird.
    */
    void EnemyDeath(){

       GameObject spwans = Instantiate(enemyDeathEffect,transform.position,Quaternion.identity);
       spwans.transform.parent=parent;
        Destroy(gameObject);
    }

}



