using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DialogueManager : MonoBehaviour {
    
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    [SerializeField]
    private GameObject dialoguePanel;

    private Queue<string> sentences;

    void Start() {
        sentences = new Queue<string>();

        dialoguePanel.SetActive(false);
    }

    public void StartDialogue (Dialogue dialogue) {
        dialoguePanel.SetActive(true);
        Debug.Log("Dialogue start");
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
            // Debug.Log(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence () {
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;

    }

    void EndDialogue () {
        Debug.Log("Dialogue End");

        dialoguePanel.SetActive(false);
    }

}
