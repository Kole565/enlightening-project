using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTrigger : MonoBehaviour {

    [SerializeField] private GameObject menu;
    [SerializeField] private float interactionLatency;

    private bool isCanInteract = true;

    void Start () {
        menu.SetActive(false);
    }

    void OnTriggerStay2D (Collider2D other) {
        if (other.gameObject.tag != "Player") {
            return;
        }

        if (Input.GetAxis("Interact") == 0) {
            return;
        }

        if (!isCanInteract) {
            return;
        }

        StartCoroutine(WaitInteractionDelay());

        menu.SetActive(!menu.activeSelf);
    }

    void OnTriggerExit2D (Collider2D other) {
        if (other.gameObject.tag != "Player") {
            return;
        }

        menu.SetActive(false);
    }

    IEnumerator WaitInteractionDelay () {
        isCanInteract = false;
        yield return new WaitForSeconds(interactionLatency);
        isCanInteract = true;
    }

}
