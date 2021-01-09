using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorColorChange : MonoBehaviour
{
    private Material _mat;

    public Color[] lv = new Color[3];
    float timer = 0;


    void Start()
    {

        Renderer nRend = GetComponent<Renderer>();
        _mat = nRend.material;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (tag == "ge_r")
        {
            _mat.SetColor("_BaseColor", lv[particletest.countR]);
            if (timer > 4)
            {
                particletest.countR = 0;
                timer = 0;
            }

        }
        else if (tag == "ge_g")
        {
            _mat.SetColor("_BaseColor", lv[particletest.countG]);
            if (timer > 4)
            {

                timer = 0;
                particletest.countG = 0;
                
            }

        }
        else if (tag == "ge_b")
        {
            _mat.SetColor("_BaseColor", lv[particletest.countB]);
            if (timer > 4)
            {

                timer = 0;
                particletest.countB = 0;
                
            }

        }
        else if (tag == "ge_p")
        {
            _mat.SetColor("_BaseColor", lv[particletest.countP]);
            if (timer > 4)
            {

                particletest.countP = 0;
                timer = 0;
            }

        }
        else if (tag == "ge_y")
        {
            _mat.SetColor("_BaseColor", lv[particletest.countY]);
            if (timer > 4)
            {

                particletest.countY = 0;
                timer = 0;
            }

        }

    }

}
