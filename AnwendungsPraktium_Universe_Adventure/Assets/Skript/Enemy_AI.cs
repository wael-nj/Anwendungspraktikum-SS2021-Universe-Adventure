using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{


    


    /*

    distance              
    transformPlayer    aktulle Koordinaten des Spieler
    checkDisatnce      wie viel ist die Abstand zwischen den Gegener und der Spieler
    rotationspeed      Genger Roationsgeschwindigkeit 
    moveEnemyspeed     Genger Bewegungsgeschwindigkeit zum Spieler 
    trackZone          Distanz vom Verfolgen  
    attackZone         Distanz des Angriffes 

    */
    [Header("Enemy AI Setting")]
    [SerializeField] float distance;
    [SerializeField] Transform transformPlayer;
    [SerializeField] float checkDisatnce = 100f;

    [SerializeField] float rotationspeed = 3.0f;
    [SerializeField] float moveEnemyspeed = 10f;
    [SerializeField] float trackZone = 50f;
    [SerializeField] float attackZone = 30f;

    [SerializeField] float lifeReduce = 20f;
    [SerializeField] float attackInterval = 1f;

    [SerializeField] GameObject[] lasers;
  
    private float attackTime;

    /*
         Bestimmung der aktuellen Position der Spieler 
         Bestimmung der aktuellen Zeit bis zum Angriff. 

    */
    void Start()
    {

        transformPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        attackTime = Time.time;

    }


   

    /*
  
        die Entfernung zwischen den Spielern und den Gegnern wird berechnet

        Solange der Spieler noch nicht vom Gegner entdeckt wurde, wird die Methode Check() aufgerufen
        
        Wenn der Spieler in die Zone des Gegners eindringt, wird die Methode Attack() aufgerufen, um den Angriff zu starten.

        Der Spieler wird vom Gegner verfolgt, wenn er die Verfolgungszone erreicht.  

    */
    void Update()
    {
        distance = Vector3.Distance(transformPlayer.position, transform.position);
        if (distance < checkDisatnce)
        {
            Check();
           
        }
        if (distance < attackZone)
        {
            attack();
            

        }
        else if (distance < trackZone)
        {
            trackTarget();
             
           
        }
    }

    void Check()
    {
        /*
            Look at Spieler ???
        */
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(transformPlayer.position - transform.position), rotationspeed * Time.deltaTime);
    }

    void trackTarget()
    {

         /*
            Gegnerbewegung zum Spieler
        */
        transform.position += transform.forward * moveEnemyspeed * Time.deltaTime;
        setlaserON(false);
    }


    /*
       Beim Angriff wird der LaserEffact aktiviert und die Methode GitHit() im Life-Skript aufgerufen, so dass das Leben des Spielers reduziert wird.
       Außerdem wird der Angriff jede Sekunde durchgeführt.


    */
    void attack()
    {
        setlaserON(true);

        if (Time.time > attackTime)
        {
            transformPlayer.SendMessage("GetHit", lifeReduce, SendMessageOptions.DontRequireReceiver);
            attackTime = Time.time + attackInterval;
        }
    }


    /*
        Laser aktiviert Method
    */
    void setlaserON(bool isActive)
    {

        foreach (GameObject item in lasers)
        {

            var emissionModule = item.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }


    }

}
