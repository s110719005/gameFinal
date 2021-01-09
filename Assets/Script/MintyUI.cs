using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MintyUI : MonoBehaviour
{
    // Start is called before the first frame update
    public static int MintyLifeCount = 5;
    public GameObject[] MintyLifeList = new GameObject[5];
    public GameObject[] MintyWeaponList = new GameObject[6];
    public GameObject Lamp;
    public GameObject Control;
    private float timer;
    private float timerStart;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerStart += Time.deltaTime;
        if (timerStart > 5)
        {
            Control.SetActive(false);
        }

        if (MintyLifeCount < 5)
        {
            timer += Time.deltaTime;
        }
        else if (MintyLifeCount == 5) timer = 0;
        if (timer > 3)
        {
            if (MintyLifeCount < 5)
            {
                MintyLifeCount++;
                
            }
            timer = 0;
        }
        if (MintyLifeCount == 5)
        {
            MintyLifeList[4].SetActive(true);
            MintyLifeList[3].SetActive(true);
            MintyLifeList[2].SetActive(true);
            MintyLifeList[1].SetActive(true);
            MintyLifeList[0].SetActive(true);
        }
        else if (MintyLifeCount == 4)
        {
            MintyLifeList[4].SetActive(false);
            MintyLifeList[3].SetActive(true);
            MintyLifeList[2].SetActive(true);
            MintyLifeList[1].SetActive(true);
            MintyLifeList[0].SetActive(true);
        }
        else if (MintyLifeCount == 3)
        {
            MintyLifeList[4].SetActive(false);
            MintyLifeList[3].SetActive(false);
            MintyLifeList[2].SetActive(true);
            MintyLifeList[1].SetActive(true);
            MintyLifeList[0].SetActive(true);
        }
        else if (MintyLifeCount == 2)
        {
            MintyLifeList[4].SetActive(false);
            MintyLifeList[3].SetActive(false);
            MintyLifeList[2].SetActive(false);
            MintyLifeList[1].SetActive(true);
            MintyLifeList[0].SetActive(true);
        }
        else
        {
            MintyLifeList[4].SetActive(false);
            MintyLifeList[3].SetActive(false);
            MintyLifeList[2].SetActive(false);
            MintyLifeList[1].SetActive(false);
            MintyLifeList[0].SetActive(false);
        }
        if (NewCharacterMovement.weaponNum == 1)
        {
            MintyWeaponList[0].SetActive(true);
            MintyWeaponList[1].SetActive(false);
            MintyWeaponList[2].SetActive(false);
            MintyWeaponList[3].SetActive(false);
            MintyWeaponList[4].SetActive(false);
            MintyWeaponList[5].SetActive(false);
        }
        if (NewCharacterMovement.weaponNum == 2)
        {
            MintyWeaponList[0].SetActive(false);
            MintyWeaponList[1].SetActive(true);
            MintyWeaponList[2].SetActive(false);
            MintyWeaponList[3].SetActive(false);
            MintyWeaponList[4].SetActive(false);
            MintyWeaponList[5].SetActive(false);
        }
        if (NewCharacterMovement.weaponNum == 3)
        {
            MintyWeaponList[0].SetActive(false);
            MintyWeaponList[1].SetActive(false);
            if (Lamp.tag == "yellow")
            {
                MintyWeaponList[2].SetActive(false);
                MintyWeaponList[3].SetActive(true);
                MintyWeaponList[4].SetActive(false);
                MintyWeaponList[5].SetActive(false);
            }
            else if (Lamp.tag == "blue")
            {
                MintyWeaponList[2].SetActive(false);
                MintyWeaponList[3].SetActive(false);
                MintyWeaponList[4].SetActive(true);
                MintyWeaponList[5].SetActive(false);
            }
            else if (Lamp.tag == "blue")
            {
                MintyWeaponList[2].SetActive(false);
                MintyWeaponList[3].SetActive(false);
                MintyWeaponList[4].SetActive(false);
                MintyWeaponList[5].SetActive(true);
            }
            else 
            {
                MintyWeaponList[2].SetActive(true);
                MintyWeaponList[3].SetActive(false);
                MintyWeaponList[4].SetActive(false);
                MintyWeaponList[5].SetActive(false);
            }

        }
    }
}
