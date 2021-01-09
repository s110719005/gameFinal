using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateDoor : MonoBehaviour
{
    public GameObject doorLeft;
    public GameObject doorRight;
    public Transform targetLeft;
    public Transform targetRight;
    public float speed = 0.3f;
    bool dooropen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (dooropen)
        {
            doorLeft.transform.position = Vector3.MoveTowards(doorLeft.transform.position, targetLeft.position, step);
            doorRight.transform.position = Vector3.MoveTowards(doorRight.transform.position, targetRight.position, step);
        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key")
        {
            dooropen = true;
            Debug.Log("open!");
        }
    }
}
