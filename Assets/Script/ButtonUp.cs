using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUp : MonoBehaviour
{
    
    
    //public GameObject elf;
    float moveTo = 0.3f;
    public static int buttonUp = 0;
    public bool buttonBeenActive = true;
    Collider other;

    void Update() {


        if (tag == "red"){
            if (buttonBeenActive && !other)
            {
                transform.position = transform.position + new Vector3(0, moveTo, 0);
                buttonBeenActive = false;
                buttonUp += 1;
                Debug.Log("buttonUp:"+buttonUp);
            }
        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "red")
        {
            buttonBeenActive = true;
            this.other = other;
        }
        

        
        
        
    }

    void OnTriggerExit(Collider other)
    {
        if ((other.tag =="yellow"|| other.tag == "blue")&& buttonBeenActive == true)
        {
            transform.position = transform.position + new Vector3(0, moveTo, 0);
            buttonBeenActive = false;
            buttonUp += 1;
            Debug.Log("buttonUp:" + buttonUp);
        }

        
    }



}
