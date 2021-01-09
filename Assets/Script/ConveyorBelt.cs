using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> onBelt;
    public static ConveyorBelt instance;
    public Vector3 direction;
    public float speed=1;
    public float maxSpeed;
    //public GameObject button;
    public GameObject start;
    public GameObject end;
    bool trigger;


    void Start()
    {
        //speed = 1;

    }

    void Update()
    {
        direction = (end.transform.position - start.transform.position).normalized;
        for (int i=0; i <= onBelt.Count - 1; i++)
        {
            onBelt[i].GetComponent<Rigidbody>().velocity = speed * direction * Time.deltaTime;
        }
       
    }
    void OnTriggerEnter(Collider col)
    {

        //direction.Set(-1, 0, 0);
        onBelt.Add(col.gameObject);

    }
    private void OnTriggerExit(Collider col)
    {
        onBelt.Remove(col.gameObject);
    }



    //when sth hit the belt
    private void OnCollisionEnter(Collision collision)
    {
        //onBelt.Add(collision.gameObject);
        onBelt.Remove(collision.gameObject);
    }

    //when sth leaves the belt

    private void OnCollisionExit(Collision collision)
    {
        //onBelt.Remove(collision.gameObject);
    }
}
