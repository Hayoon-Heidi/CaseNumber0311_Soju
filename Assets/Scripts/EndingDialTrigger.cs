using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingDialTrigger : MonoBehaviour
{
    public EndingDialouge enddialouge;


    void Start()
    {
        FindObjectOfType<EndingDialManager>().TrueEndingTalking();

        //Call TriggerDialouge class after 2 mins.
        Invoke("TriggerDialouge", 2);
    }

    public void TriggerDialouge()
    {
        FindObjectOfType<EndingDialManager>().StartEndingDialouge(enddialouge);
    }
}
