using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmallDialManager : MonoBehaviour
{
    public Text dialougeText;
    private Queue<string> sentences;

    public bool Smalltalking = false;
    public bool finish = false;

    public Animator animDialogueWindow;

    private void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        if (finish == false && Smalltalking == false && Input.GetKeyDown(KeyCode.Z))
        {
            Smalltalking = true;
            DisplayNextSmallSentence();
        }

    }

    public void StartSmallDialouge(SmallDialouge dialouge)
    {
        Smalltalking = true;
        finish = false;
        sentences.Clear();

        animDialogueWindow.SetBool("SmallAppear", true);

        foreach (string sentence in dialouge.sentences)
        {
            sentences.Enqueue(sentence);

        }

        DisplayNextSmallSentence();

    }

    public void DisplayNextSmallSentence()
    {
        if (sentences.Count == 0)
        {
            EndSmallDialouge();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSmallSentence(sentence));
    }

    IEnumerator TypeSmallSentence(string sentence)
    {
        dialougeText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {


            dialougeText.text += letter;
            yield return new WaitForSeconds(0.05f);


        }

        Smalltalking = false;
    }

    void EndSmallDialouge()
    {
        animDialogueWindow.SetBool("SmallAppear", false);
        Smalltalking = false;
        finish = true;
    }
}
