using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    // Start is called before the first frame update ** die Zeile ist nötig? können wir es löschen?
    public GameObject player;
    private Vector3 offset;

    private Vector3 newTransform;

    /*
         die ursprüngliche Ansicht der Kamera auf der Grundlage des Spielers festzulegen und 
         den Offset auf der Grundlage der ursprünglichen Position zu berechnen.
         Dieser Offset wird beibehalten, um die Ansicht zu erhalten.
        
    */
    void Start()
    {

        offset.x = transform.position.x - player.transform.position.x;
        offset.y = transform.position.y - player.transform.position.y;
        offset.z = transform.position.z - player.transform.position.z;
        newTransform = transform.position;


    }
        /*
            sollte eine Verfolgungskamera immer in LateUpdate implementiert werden, 
            da sie Objekte verfolgt, die sich innerhalb von Update bewegt haben könnten.

          
        */
    void LateUpdate()
    {
        /*
             Die genauen Koordinaten der Kameraposition basierend auf der X-, Y- und Z-Achse des Players aktualisieren. 
        */
        newTransform.x = player.transform.position.x + offset.x;
        newTransform.y = player.transform.position.y + offset.y;
        newTransform.z = player.transform.position.z + offset.z;
        transform.position = newTransform;
    }
}
