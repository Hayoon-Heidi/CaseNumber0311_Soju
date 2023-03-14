using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitManager : MonoBehaviour
{

    public GameObject exitTheGame;
    private bool exitactive;

    // Start is called before the first frame update
    void Start()
    {
        exitTheGame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            exitTheGame.SetActive(true);
            exitactive = true;
        }

        if (exitactive && Input.GetKeyDown(KeyCode.Y))
        {
            Application.Quit();
        }

        if (exitactive && Input.GetKeyDown(KeyCode.N))
        {
            exitactive = false;
            exitTheGame.SetActive(false);
        }
    }
}
