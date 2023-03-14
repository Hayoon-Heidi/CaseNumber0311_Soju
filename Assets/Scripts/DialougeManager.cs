using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialougeManager : MonoBehaviour
{

    public Text dialougeText;
    public SpriteRenderer spriteRenderer;
    public Animator anim;
    private Queue<string> sentences;
    private Queue<Sprite> sprites;
    private int ChangeNumber;
    public bool needChoice;

    public bool talking = false;

    private void Start()
    {
        sentences = new Queue<string>();
        sprites = new Queue<Sprite>();

    }

    private void Update()
    {
        if (talking == false && Input.GetKeyDown(KeyCode.Z))
        {
            DisplayNextSentence();
        }

    }

    public void StartDialouge(Dialouge dialouge)
    {
        ChangeNumber = dialouge.ChangeNumber;
        talking = true;
        sentences.Clear();
        anim.SetBool("Appear", true);


        foreach(string sentence in dialouge.sentences)
        {
            sentences.Enqueue(sentence);

        }

        foreach(Sprite sprite in dialouge.sprites)
        {
            sprites.Enqueue(sprite);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        talking = true;
        if (sentences.Count == 0)
        {
            EndDialouge();
            return;
        }

        string sentence = sentences.Dequeue();
        Sprite sprite = sprites.Dequeue();
        spriteRenderer.sprite = sprite;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialougeText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {


            dialougeText.text += letter;
            yield return new WaitForSeconds(0.05f);


        }

        talking = false;
    }

    void EndDialouge()
    {
        Debug.Log("End of conversation");

        if(needChoice)
        {
            Debug.Log("NeedChoice");
            anim.SetBool("Appear", false);
            dialougeText.text = "";
            FindObjectOfType<ChoiceManager>().ShowChoice();
            needChoice = false;
        }
        else
        {
            Debug.Log("No NeedChoice");
            FindObjectOfType<SceneChanger>().FadeToScene(ChangeNumber);
        }
       

    }

    public void TrueTalking()
    {
        talking = true;

    }

}
