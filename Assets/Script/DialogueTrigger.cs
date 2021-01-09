using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

	public GameObject dialogueBox;
    public GameObject[] Charactername = new GameObject[10];
    public GameObject[] Charactertext = new GameObject[10];
    public static int dialogueStart=0;
    public GameObject delete;
    
    int currentDialogueCount=0;
    int newcurrentDialogueCount = 0;

    private void Update()
    {
        newcurrentDialogueCount = NewCharacterMovement.dialogueCount;


    }
    private void OnTriggerEnter(Collider other)
    {
        dialogueStart = 1;
        NewCharacterMovement.currentDialogueStart = true;
    }

    private void OnTriggerStay(Collider other)
    {

        Debug.Log("trigger!");
        //Debug.Log("dialogueCount:" + NewCharacterMovement.dialogueCount);
        if (dialogueStart == 1 && other.tag=="Player")
        {
            
            if (newcurrentDialogueCount >= Charactername.Length)//關閉對話
            {
                dialogueBox.SetActive(false);
                Charactername[Charactername.Length-1].SetActive(false);
                Charactertext[Charactername.Length-1].SetActive(false);
                dialogueStart = 0;
                currentDialogueCount = 0;
                newcurrentDialogueCount = 0;
                NewCharacterMovement.dialogueCount = 0;
                NewCharacterMovement.currentDialogueStart = false;
                Destroy(delete);
            }
            else if (currentDialogueCount < newcurrentDialogueCount)//按繼續鍵之後會顯示下一個對話
            {
                Charactername[currentDialogueCount].SetActive(false);
                Charactertext[currentDialogueCount].SetActive(false);
                Charactername[newcurrentDialogueCount].SetActive(true);
                Charactertext[newcurrentDialogueCount].SetActive(true);
                currentDialogueCount++;

            }
            else if (currentDialogueCount == 0)//0的時候顯示第一則對話
            {
                
                dialogueBox.SetActive(true);
                Charactername[currentDialogueCount].SetActive(true);
                Charactertext[currentDialogueCount].SetActive(true);

            }
        }
        
    



    }
   

}