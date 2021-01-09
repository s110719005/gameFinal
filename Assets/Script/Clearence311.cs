using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clearence311 : MonoBehaviour
{
    public static bool clearence = false;
    public GameObject key;
    public GameObject bigKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var usersize = new Vector3(0.1f, 0.1f, 0.1f);
        var bigtransform = new Vector3(0.23f, 0.04f, -30f);
        if (clearence == true)
        {
            key.transform.localScale = Vector3.Slerp(key.transform.localScale, usersize, Time.deltaTime * 2);
            

        }
    }
    void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.tag == "Key")
        {
            clearence = true;
            bigKey.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }

}
