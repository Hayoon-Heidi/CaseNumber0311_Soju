using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeTrigger : MonoBehaviour
{
    public Dialouge dialouge;

    void Start()
    {
        FindObjectOfType<DialougeManager>().TrueTalking();

        //Call TriggerDialouge class after 2 mins.
        Invoke("TriggerDialouge", 2);
    }

    public void TriggerDialouge ()
    {
        FindObjectOfType<DialougeManager>().StartDialouge(dialouge);
    }

}
