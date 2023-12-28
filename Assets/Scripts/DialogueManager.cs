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
    [SerializeField] private PlayerController player;

    void Start() {
        sentences = new Queue<string>();

        dialoguePanel.SetActive(false);
    }

    public void StartDialogue (Dialogue dialogue) {
        player.isActive = false;

        dialoguePanel.SetActive(true);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
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
        player.isActive = true;

        dialoguePanel.SetActive(false);
    }

}
