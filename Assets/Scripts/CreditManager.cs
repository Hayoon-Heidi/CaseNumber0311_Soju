using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditManager : MonoBehaviour
{

    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;

    public Animator creditAnim;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartCredit1", 1);
        Invoke("EndCredit1", 4);
        Invoke("StartCredit2", 5);
        Invoke("EndCredit2", 9);
        Invoke("StartCredit3", 10);
        Invoke("EndCredit3", 20);
        Invoke("StartCredit4", 21);
        Invoke("EndCredit4", 30);
        Invoke("StartCredit5", 31);
    }

    public void StartCredit1()
    {
        creditAnim.SetBool("open", true);
    }

    public void EndCredit1()
    {
        creditAnim.SetBool("open", false);
    }

    public void StartCredit2()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
        creditAnim.SetBool("open", true);
    }

    public void EndCredit2()
    {
        creditAnim.SetBool("open", false);
    }

    public void StartCredit3()
    {
        panel2.SetActive(false);
        panel3.SetActive(true);
        creditAnim.SetBool("open", true);
    }
    public void EndCredit3()
    {
        creditAnim.SetBool("open", false);
    }

    public void StartCredit4()
    {
        panel3.SetActive(false);
        panel4.SetActive(true);
        creditAnim.SetBool("open", true);
    }

    public void EndCredit4()
    {
        creditAnim.SetBool("open", false);
    }

    public void StartCredit5()
    {
        panel4.SetActive(false);
        SceneManager.LoadScene(0);
    }

}
