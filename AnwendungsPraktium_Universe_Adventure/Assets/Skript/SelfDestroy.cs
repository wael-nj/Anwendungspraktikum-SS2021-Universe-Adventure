using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{


    /*
        Zerstörungseffekt der Explosion
       
        Wird beim Gegner-Explosion verwendet
    
    */
    [SerializeField] float destroyTime=3f;
    
    void Start()
    {
        Destroy(gameObject,destroyTime);
    }

   
}
