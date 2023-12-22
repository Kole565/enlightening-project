using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;
    public DialogueManager dialogueManager;
    private bool isUsed = false;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" & !isUsed) {
            TriggerDialogue();
            isUsed = true;
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag != "Player") {
            return;
        }

        if (Input.GetAxis("Interact") == 0) {
            return;
        }

        dialogueManager.DisplayNextSentence();
    }

    public void TriggerDialogue () {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}
