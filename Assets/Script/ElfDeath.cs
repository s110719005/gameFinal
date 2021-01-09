using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfDeath : MonoBehaviour
{
    float health;
    public HealthBar healthBar;
    public GameObject Elf;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health = healthBar.slider.value;
        if (health <0.5f)
        {
            Destroy(Elf);
        }
    }

    

}
