﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxinController : MonoBehaviour
{
    public ParticleSystem toxinGunPS;
    public ParticleSystem burstPS;
    List<ParticleCollisionEvent> collisionEvent;
    public static int countR = 0;
    public static int countG = 0;
    public static int countB = 0;
    public static int countP = 0;

    // Start is called before the first frame update
    void Start()
    {
        //DoEmit，0秒鐘後開始，每0.3秒一次
        InvokeRepeating("DoEmit", 0f, 0.3f);
        collisionEvent = new List<ParticleCollisionEvent>();
    
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    /*
    void OnParticleCollision(GameObject other)
    {
        
        ParticlePhysicsExtensions.GetCollisionEvents(toxinGunPS, other, collisionEvent);
        
        for (int i = 0; i < collisionEvent.Count; i++)
        {
            Vector3 pos = collisionEvent[i].intersection;
            burstPS.transform.position = collisionEvent[i].intersection;
            
        }
        
        burstPS.Play();
        //子彈碰到發電機+1
        if (other.tag == "ge_r")
        {
            countR = (countR + 1) % 3;
        }
        else if (other.tag == "ge_g")
        {
            countG = (countG + 1) % 3;
        }
        else if (other.tag == "ge_b")
        {
            countB = (countB + 1) % 3;
        }
        else if (other.tag == "ge_p")
        {
            countP = (countP + 1) % 3;
        }
        Debug.Log("R:"+countR);
        Debug.Log("G:" + countG);
        Debug.Log("B:" + countB);
        Debug.Log("P:" + countP);
    }
    */
    void DoEmit()
    {
        
        if (NewCharacterMovement.pressDown == true&& NewCharacterMovement.toxinGunOn==true)
        {
            toxinGunPS.Emit(1);
            toxinGunPS.Play();
        }
       
    }
}
