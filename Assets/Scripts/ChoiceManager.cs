using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceManager : MonoBehaviour
{
    public GameObject[] answerPanel;
    public Animator anim;

    public bool choiceIng;
    public Dialouge dialouge_1;
    public Dialouge dialouge_2;
    private bool keyInput; 

    public int count; 
    private int result; 

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= 1; i++)
        {
            answerPanel[i].SetActive(false);
        }
    }

    public void ShowChoice()
    {
        choiceIng = true;
        result = 0;
        anim.SetBool("ChoiceAppear", true);

        for (int i = 0; i <= 1; i++)
        {
            answerPanel[i].SetActive(true);
        }
        Selection();
        keyInput = true;
    }

    public void Selection()
    {
        Debug.Log("Selection");

        Color color = answerPanel[0].GetComponent<Outline>().effectColor;
        color.a = 0;
        for (int i = 0; i <= count; i++)
        {
            answerPanel[i].GetComponent<Outline>().effectColor = color;
        }
        color.a = 0.85f;
        answerPanel[result].GetComponent<Outline>().effectColor = color;
    }

    public void ExitChoice()
    {

        anim.SetBool("ChoiceAppear", false);
        choiceIng = false;

        if (result == 0)
        {
            FindObjectOfType<DialougeManager>().StartDialouge(dialouge_1);
        } else if (result == 1)
        {
            FindObjectOfType<DialougeManager>().StartDialouge(dialouge_2);
        }

    }

    public int GetResult()
    {
        return result;
    }

    // Update is called once per frame
    void Update()
    {
        if (keyInput)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (result > 0)
                    result--;
                else
                    result = count;
                Selection();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (result < count)
                    result++;
                else
                    result = 0;
                Selection();
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                keyInput = false;
                ExitChoice();
                Debug.Log("End Choice the result is " + result);
            }
        }
    }
}
