using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [System.Serializable]
    public class Dialogue
    {   
        public string name;
        [TextArea(3,10)]
        public string sentences;
    }
    public Animator animator;
    public Transform kingTextPos;
    public Transform mageTextPos;
    public GameObject bubble;
    public  TMP_Text dialogueText;
    public Queue<string> nameOrder;
    public Queue<string> sentences;

    public Dialogue[] dialogues;

    // Start is called before the first frame update
    void Start()
    {
        nameOrder = new Queue<string>();
        sentences = new Queue<string>();
        StartDialogue(dialogues);
    }

    // Update is called once per frame
    public void StartDialogue(Dialogue[] dialogues){
        Debug.Log("Starting conversation with " + dialogues[0].name);
        nameOrder.Clear();
        sentences.Clear();
        foreach(Dialogue dialog in dialogues){
            nameOrder.Enqueue(dialog.name);
            sentences.Enqueue(dialog.sentences);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        dialogueText.text = "";
        if(sentences.Count == 0){
            return;
        }
        string name = nameOrder.Dequeue();
        string sentence = sentences.Dequeue();

        if(name == "King"){
            animator.SetBool("MageTalking", false);
        }
        else if(name == "Mage"){
            animator.SetBool("MageTalking", true);
        }
        Debug.Log(sentence);
        //animator open dialogue box
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence){
        dialogueText.text = "";
        animator.SetBool("SpeechOpen", true);
        yield return new WaitForSeconds(1.5f);
        foreach(char letter in sentence.ToCharArray()){
            bubble.GetComponent<RectTransform>().localScale = new Vector3(-1,1,1);
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.07f);
        }
        yield return new WaitForSeconds(1f);
        dialogueText.text = "";
        animator.SetBool("SpeechOpen", false);
        yield return new WaitForSeconds(3f);
        DisplayNextSentence();
    }
}
