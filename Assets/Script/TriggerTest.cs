using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    // Start is called before the first frame update

    
    public GameObject belt1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        StartCoroutine(RotateMe(1.5f));

    //        //Debug.Log("trigger!");
    //    }
           

    //}

    public ParticleSystem ps;

    // these lists are used to contain the particles which match
    // the trigger conditions each frame.

    //List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
    //List<ParticleSystem.Particle> exit = new List<ParticleSystem.Particle>();

    void OnEnable()
    {
        ps = GetComponent<ParticleSystem>();
        Debug.Log("enable");
    }

    void OnParticleTrigger()
    {
        StartCoroutine(RotateMe(1.5f));
        Debug.Log("trigger!");
    }




    IEnumerator RotateMe(float inTime)
    {
        var fromAngle = belt1.transform.rotation;
        //var toAngle = Quaternion.Euler(0,0, 0);
        var toAngle = Quaternion.Euler(0, 0, belt1.transform.rotation.eulerAngles.z + 90);
        Debug.Log("toAngle"+toAngle.eulerAngles);
        Debug.Log("fromAngle" + fromAngle.eulerAngles);

        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            belt1.transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            belt1.transform.rotation = Quaternion.Euler(new Vector3(fromAngle.eulerAngles.x, fromAngle.eulerAngles.y, belt1.transform.rotation.eulerAngles.z));
            yield return null;

            
        }
    }
    

}
