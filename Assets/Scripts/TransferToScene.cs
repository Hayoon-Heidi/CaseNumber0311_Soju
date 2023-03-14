using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferToScene : MonoBehaviour
{

    public Animator animator;
    private int SceneToLoad;
    public int TransferScene;
    private bool enterTransfer = false;

    private MovingObject theMoving;

    // Start is called before the first frame update
    void Start()
    {
        theMoving = FindObjectOfType<MovingObject>();
    }

    private void Update()
    {
        if(enterTransfer)
        {
            FindObjectOfType<SceneChanger>().FadeToScene(TransferScene);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enterTransfer = true;
    }
}
