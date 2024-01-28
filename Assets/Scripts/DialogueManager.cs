using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public Animator trans;
    public GameObject bubble;
    public  TMP_Text dialogueText;
    public Queue<string> nameOrder;
    public Queue<string> sentences;

    public Dialogue[] introDialogue;
    public Dialogue[] winDialogue;
    public Dialogue[] timerDialogue;
    public Dialogue[] kingDiedDialogue;
    // Start is called before the first frame update
    void Start()
    {
        nameOrder = new Queue<string>();
        sentences = new Queue<string>();
        StartDialogue(introDialogue);
        trans.SetTrigger("transOut");
    }
    public void TimerFinish(){
        trans.SetTrigger("transIn");
        StartCoroutine(ChangeScene());
        // StartDialogue(timerDialogue);

    }

    public void KingDied(){
        StartDialogue(kingDiedDialogue);
    }
    bool dying = false;
    public void Died(){
        if(!dying){
            dying = true;
            trans.SetTrigger("transIn");
            StartCoroutine(ChangeScene());
        }
    }

    IEnumerator ChangeScene(){
        yield return new WaitForSeconds(0.4f);
        Debug.Log("Change Scene");
        SceneManager.LoadScene(1);
    }

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

    public void Win(){
        // StartDialogue(winDialogue);
        trans.SetTrigger("transIn");
        SceneManager.LoadScene(Random.Range(2, 3));
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
        yield return new WaitForSeconds(1f);
        foreach(char letter in sentence.ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(1f);
        animator.SetBool("SpeechOpen", false);
        yield return new WaitForSeconds(0.3f);
        dialogueText.text = "";
        yield return new WaitForSeconds(1f);
        DisplayNextSentence();
    }
}
