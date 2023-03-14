using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{

    [SerializeField]
    public SmallDialouge dialouge;

    private SmallDialManager theDM;
    private OrdereManager theOrder;
    private MovingObject theMoving;

    //this will determine characters direction. How to write it? idk...
    public bool up;
    public bool down;
    public bool left;
    public bool right;
    public bool TalkStart;
    public int SceneNumber;

    private bool flag;
    private bool movingInRange;


    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<SmallDialManager>();
        theOrder = FindObjectOfType<OrdereManager>();
        theMoving = FindObjectOfType<MovingObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        movingInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        movingInRange = false;
    }

    IEnumerator EventCoroutine()
    {
        theOrder.NotMove();
        theDM.StartSmallDialouge(dialouge);

        yield return new WaitUntil(() => theDM.finish);
        theOrder.Move();
        flag = false;
    }

    private void EventStart()
    {
        flag = true;
        StartCoroutine(EventCoroutine());
    }


    // Update is called once per frame
    void Update()
    {

        if (movingInRange && !flag && Input.GetKeyDown(KeyCode.Z))
        {

            if (TalkStart)
            {
                TalkStart = false;

                Debug.Log("Fade to other scene");
                FindObjectOfType<SceneChanger>().FadeToScene(SceneNumber);

            }
            else
            {
                if (up && theMoving.animator.GetFloat("DirY") == 1f)
                {
                    EventStart();
                }
                else if (down && theMoving.animator.GetFloat("DirY") == -1f)
                {
                    EventStart();
                }
                else if (right && theMoving.animator.GetFloat("DirX") == 1f)
                {
                    EventStart();
                }
                else if (left && theMoving.animator.GetFloat("DirX") == -1f)
                {
                    EventStart();
                }

            }
        }

    }
}
