using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{


    /*
       ?? Zerstörungseffekt der Explosion
       ?? Explosion effekt oder wie???
       Wird beim Gegner-Explosion verwendet
       ?? Das zerstörte Gegner-Objekt wird im Spiel entferntet.
    */
    [SerializeField] float destroyTime=3f;
    
    void Start()
    {
        Destroy(gameObject,destroyTime);
    }

   
}
