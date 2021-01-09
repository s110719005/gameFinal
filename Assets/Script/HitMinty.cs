using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMinty : MonoBehaviour
{
    private int count=0;
    private float timer;
    bool shootbreak = false;
    int hitCount=0;
    public GameObject D6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            shootbreak = true;
            timer = 0;
        }
    }
    void OnParticleCollision(GameObject other)
    {
        count++;
        D6.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        if (shootbreak)
        {
            MintyUI.MintyLifeCount--;
            shootbreak = false;
            //hitCount++;
        }
        if (count > 1000) count = 0;
        
    }
}
