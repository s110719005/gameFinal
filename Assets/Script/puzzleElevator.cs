using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleElevator : MonoBehaviour
{
    public GameObject elevator;
    public float speed = 1f;
    public Transform target;
    bool exit=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (exit)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        
    }

    void OnTriggerEnter(Collider col)
    {

        //direction.Set(-1, 0, 0);
        //onBelt.Add(col.gameObject);

    }

    private void OnTriggerExit(Collider col)
    {
        if(col.tag == "Key")
        {
            exit = true;
        }
        
    }
}
