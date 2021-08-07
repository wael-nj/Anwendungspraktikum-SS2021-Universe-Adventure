using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{


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

   
    void Start()
    {

        transformPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        attackTime = Time.time;

    }

    // Update is called once per frame
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
       
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(transformPlayer.position - transform.position), rotationspeed * Time.deltaTime);
    }

    void trackTarget()
    {
        transform.position += transform.forward * moveEnemyspeed * Time.deltaTime;
        setlaserON(false);
    }

    void attack()
    {
        setlaserON(true);

        if (Time.time > attackTime)
        {
            transformPlayer.SendMessage("GetHit", lifeReduce, SendMessageOptions.DontRequireReceiver);
            attackTime = Time.time + attackInterval;
        }
    }

    void setlaserON(bool isActive)
    {

        foreach (GameObject item in lasers)
        {

            var emissionModule = item.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }


    }

}
