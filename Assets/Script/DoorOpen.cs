using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public float speed = 0.3f;
    public Transform target;
    public GameObject D2_3;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (Clearence311.clearence && tag!="ge_y")
        {
            
            
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            D2_3.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        }
        else if (particletest.countY == 4 && tag == "ge_y")
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            count++;
            if(count>50) D2_3.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
}
