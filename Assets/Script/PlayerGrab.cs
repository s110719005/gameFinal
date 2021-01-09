using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    private bool hold;
    public bool canGrab = true;

    PlayerControls controls2;

    void Awake()
    {
        controls2 = new PlayerControls();
        //
        


    }
    


    void Update()
    {
        if (canGrab)
        {
            Debug.Log("cangrab!");
            if (NewCharacterMovement.grabPressDown == true)
            {
                hold = true;
                Debug.Log("grab!");
            }
            else
            {
                hold = false;
                Destroy(GetComponent<FixedJoint>());
            }
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (hold && col.transform.tag != "Player")
        {
            Rigidbody rb = col.transform.GetComponent<Rigidbody>();
            if (rb != null)
            {
                FixedJoint fj = transform.gameObject.AddComponent(typeof(FixedJoint)) as FixedJoint;
                fj.connectedBody = rb;
            }
            else
            {
                FixedJoint fj = transform.gameObject.AddComponent(typeof(FixedJoint)) as FixedJoint;
            }
        }
    }
}
