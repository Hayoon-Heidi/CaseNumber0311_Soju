using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventStart : MonoBehaviour
{
    [SerializeField]
    public SmallDialouge dialouge;

    private SmallDialManager theDM;
    private OrdereManager theOrder;
    private MovingObject theMoving;

    private bool flag;


    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<SmallDialManager>();
        theOrder = FindObjectOfType<OrdereManager>();
        theMoving = FindObjectOfType<MovingObject>();
        flag = true;
        Invoke("EventStartatStart", 1);
    }

    IEnumerator EventCoroutine()
    {


        theOrder.NotMove();
        theDM.StartSmallDialouge(dialouge);

        yield return new WaitUntil(() => theDM.finish);
        theOrder.Move();
        flag = false;
    }

    public void EventStartatStart()
    {
        if(flag)
        {
            StartCoroutine(EventCoroutine());
        }
    }


    
}
