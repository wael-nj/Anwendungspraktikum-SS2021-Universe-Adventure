using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{


    public GameObject thridCam;
    public GameObject firstCam;
    /*
            CamMode dient die Modulauswahl des Kamera

    */
    public int camMode;

    /* können wir start() nicht löschen? wenn wir nicht brauchen? */

    void Start()
    {

    }

    /*
        Im InputManger ist eine Drucktaste definiert, mit der wir die Kamera auswählen können. 
        
    */
    void Update()
    {
        if (Input.GetButton("Camera"))
        {
            if (camMode == 1)
            {
                camMode = 0;
            }
            else
            {
                camMode += 1;
            }
            StartCoroutine(camChange());
        }
    }


    /*
        Diese Methode wird verwendet, um zu bestimmen, welche Kamera aktiviert wird, wenn die bestimmte Taste gedrückt wird.  
        wenn CamMode 0, wird die dritte Kamera aktiviert und die erste Kamera deaktiviert.
        wenn CamMode 1, wird die erste Kamera  aktiviert und die dritte Kamera deaktiviert.
   */
    IEnumerator camChange()
    {
        yield return new WaitForSeconds(0.01f);
        if (camMode == 0)
        {
            thridCam.SetActive(true);
            firstCam.SetActive(false);
        }
        if (camMode == 1)
        {
            thridCam.SetActive(false);
            firstCam.SetActive(true);
        }

    }
}
