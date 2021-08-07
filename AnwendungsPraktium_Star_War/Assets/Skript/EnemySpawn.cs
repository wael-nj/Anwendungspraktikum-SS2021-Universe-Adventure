using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{


    /*
         Diese Klasse wird für die automatische Generierung von Feinden verwendet. 
            Enemy           ausgewählt Enemy
            EenemyCount     Wie viele Enemy generiert werden sollen 
            Parent klont    dieses Objekt in ein GameObject

            xPos            X-Koordinaten
            yPos            Y-Koordinaten
            zPos            Z-Koordinaten
    */

    [Header("Enemy Setup Setting")]
    [SerializeField]GameObject enemy;
    [SerializeField] int enemyCount;
    [SerializeField] Transform parent;
     int xPos;
     int yPos;
     int zPos;
    
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }


        /*
        
            Zufällige Koordinaten beschränken im Spielfeld den Bereich, 
            in dem das gegnerische Objekt das Spielfeld nicht verlassen darf.

            X-Koordinaten zwischen -40,40
            Y-Koordinaten zwischen -20,20   
            Z-Koordinaten zwischen 200,4000
        */
    IEnumerator EnemyDrop()
    {

    
        while ( 0 < enemyCount)
        {
            xPos = Random.Range(-40,40);
            yPos = Random.Range(-20,20);
            zPos = Random.Range(200,4000);

            /*
            
            Diese Funktion erstellt eine Kopie eines Objekts auf ähnliche Weise wie der Befehl Duplizieren im Editor.
            Wenn ein Spielobjekt geklont wird, können Sie seine Position und Drehung angeben 
            Wenn eine Komponente geklont wird, wird das Spielobjekt, an das sie angehängt ist, ebenfalls geklont, ebenfalls mit optionaler Position und Drehung.


            */


            GameObject spwans = Instantiate(enemy,new Vector3(xPos,yPos,zPos),Quaternion.identity);
            spwans.transform.parent=parent;
            yield return new WaitForSeconds(0.1f);
            enemyCount--;

        }

    }

}
