using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particletest : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject belt_b1;
    public GameObject belt_b2;
    public GameObject belt_r1;
    public GameObject belt_r2;
    public GameObject belt_g1;
    public GameObject belt_g2;
    public GameObject key;
    public GameObject D2_2;
    public GameObject D7;
    public Transform originkey;

    public ParticleSystem toxinGunPS;
    public ParticleSystem burstPS;
    List<ParticleCollisionEvent> collisionEvent;
    public static int countR = 0;
    public static int countG = 0;
    public static int countB = 0;
    public static int countP = 0;
    public static int countY = 0;

    //hit red elf
    public int redElfMaxHealth = 5;
    public int redElfCurrentHealth;

    public HealthBar healthBar;

    void Start()
    {

        collisionEvent = new List<ParticleCollisionEvent>();
        redElfCurrentHealth = redElfMaxHealth;
        healthBar.SetMaxHealth(redElfMaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    

    

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
            Debug.Log("R:" + countR);
            
            if (countR == 2)
            {
                StartCoroutine(RotateMe(1.5f, belt_r1, belt_r2));
            }
        }
        else if (other.tag == "ge_g")
        {
            countG = countG + 1;
            if (countG > 2) countG = 2;
            Debug.Log("G:" + countG);
            
            if (countG == 2)
            {
                StartCoroutine(RotateMe(1.5f, belt_g1, belt_g2));
            }
        }
        else if (other.tag == "ge_b")
        {
            countB = countB + 1;
            if (countB > 2) countB = 2;
            Debug.Log("B:" + countB);
            if (countB == 2)
            {
                StartCoroutine(RotateMe(1.5f, belt_b1, belt_b2));
            }

        }
        else if (other.tag == "ge_p")
        {
            countP = countP + 1;
            if (countP > 2) countP = 2;
            Debug.Log("P:" + countP);
            if (countP == 2)
            {
                key.transform.position = originkey.position;
                key.transform.rotation = originkey.rotation;
            }
        }
        else if (other.tag == "ge_y")
        {
            countY = countY + 1;
            if (countY > 4) countY = 4;
            Debug.Log("P:" + countY);
            if (countY == 2)
            {
                D2_2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }
        }
        //hit red elf
        else if(other.tag == "red")
        {
            TakeDamage(1);
            D7.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }

        




    }

    //hit red elf
    void TakeDamage(int damage)
    {
        redElfCurrentHealth -= damage;
        healthBar.SetHealth(redElfCurrentHealth);
    }


    //belt rotation
    IEnumerator RotateMe(float inTime ,GameObject belt1, GameObject belt2)
    {
        var fromAngle = belt1.transform.rotation;
        var fromAngle2 = belt2.transform.rotation;
        //var toAngle = Quaternion.Euler(0,0, 0);
        var toAngle = Quaternion.Euler(0, 0, belt1.transform.rotation.eulerAngles.z + 90);
        var toAngle2 = Quaternion.Euler(0, 0, belt2.transform.rotation.eulerAngles.z + 90);
        if (belt1.transform.rotation.eulerAngles.z > 0 && belt1.transform.rotation.eulerAngles.z <= 85)
        {
            toAngle = Quaternion.Euler(0, 0, 90);
        }
        else if(belt1.transform.rotation.eulerAngles.z > 85 && belt1.transform.rotation.eulerAngles.z <= 170)
        {
            toAngle = Quaternion.Euler(0, 0, 180);
        }
        else if (belt1.transform.rotation.eulerAngles.z > 170 && belt1.transform.rotation.eulerAngles.z <= 260)
        {
            toAngle = Quaternion.Euler(0, 0, 270);
        }
        else if (belt1.transform.rotation.eulerAngles.z > 265 && belt1.transform.rotation.eulerAngles.z <= 360)
        {
            toAngle = Quaternion.Euler(0, 0, 360);
        }

        if (belt2.transform.rotation.eulerAngles.z > 0 && belt2.transform.rotation.eulerAngles.z <= 85)
        {
            toAngle2 = Quaternion.Euler(0, 0, 90);
        }
        else if (belt2.transform.rotation.eulerAngles.z > 85 && belt2.transform.rotation.eulerAngles.z <= 170)
        {
            toAngle2 = Quaternion.Euler(0, 0, 180);
        }
        else if (belt2.transform.rotation.eulerAngles.z > 170 && belt2.transform.rotation.eulerAngles.z <= 260)
        {
            toAngle2 = Quaternion.Euler(0, 0, 270);
        }
        else if (belt2.transform.rotation.eulerAngles.z > 260 && belt2.transform.rotation.eulerAngles.z <= 360)
        {
            toAngle2 = Quaternion.Euler(0, 0, 360);
        }


        //Debug.Log("toAngle" + toAngle.eulerAngles);
        //Debug.Log("fromAngle" + fromAngle.eulerAngles);

        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            belt1.transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            belt1.transform.rotation = Quaternion.Euler(new Vector3(fromAngle.eulerAngles.x, fromAngle.eulerAngles.y, belt1.transform.rotation.eulerAngles.z));
            belt2.transform.rotation = Quaternion.Slerp(fromAngle2, toAngle2, t);
            belt2.transform.rotation = Quaternion.Euler(new Vector3(fromAngle2.eulerAngles.x, fromAngle2.eulerAngles.y, belt2.transform.rotation.eulerAngles.z));
            yield return null;


        }
    }

}
