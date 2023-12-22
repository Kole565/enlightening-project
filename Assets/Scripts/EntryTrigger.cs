using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EntryTrigger : MonoBehaviour {

    private bool inTransition = false;

    void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Player" & !inTransition) {
            StartCoroutine(FindObjectOfType<SceneController>().LoadNextScene());
            inTransition = true;
        }

    }

}
