using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{


    /*
       Zerstörungseffekt mit Explosion
        Wird beim Gegner-Explosion verwendet
    */
    [SerializeField] float destroyTime=3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,destroyTime);
    }

   
}
