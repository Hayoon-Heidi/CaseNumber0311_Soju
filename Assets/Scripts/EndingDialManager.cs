using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingDialManager : MonoBehaviour
{
    public Text dialougeText;
    private Queue<string> sentences;
    public int ChangeNumber;
    public Animator anim;

    public bool Endtalking = false;

    private void Start()
    {
        sentences = new Queue<string>();

    }

    private void Update()
    {
        if (Endtalking == false && Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("z key get");
            DisplayNextEndingSentence();
        }

    }

    public void StartEndingDialouge(EndingDialouge dialouge)
    {
        Endtalking = true;
        sentences.Clear();
        anim.SetBool("Appear", true);

        foreach (string sentence in dialouge.sentences)
        {
            sentences.Enqueue(sentence);

        }

        DisplayNextEndingSentence();

    }

    public void DisplayNextEndingSentence()
    {
        Endtalking = true;
        if (sentences.Count == 0)
        {
            EndEndingDialouge();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeEndingSentence(sentence));
    }

    IEnumerator TypeEndingSentence(string sentence)
    {
        dialougeText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {

            dialougeText.text += letter;
            yield return new WaitForSeconds(0.05f);

        }

        Endtalking = false;
    }

    void EndEndingDialouge()
    {
        Debug.Log("End of conversation");
        FindObjectOfType<SceneChanger>().FadeToScene(ChangeNumber);
    }

    public void TrueEndingTalking()
    {
        Endtalking = true;

    }
}
