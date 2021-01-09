using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigExit : MonoBehaviour
{
    public float speed = 0.3f;
    int buttonActiveCount=0;
    public GameObject DLast;
    // Start is called before the first frame update
    void Start()
    {
        buttonActiveCount = ButtonUp.buttonUp;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (ButtonUp.buttonUp> buttonActiveCount)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position - new Vector3(0, 7, 0), step);
            buttonActiveCount = ButtonUp.buttonUp;
        }
        if (buttonActiveCount == 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position - new Vector3(0, 200, 0), step);
            DLast.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        }
        
    }
}
