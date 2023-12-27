using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OpenSceneInteraction : MonoBehaviour {

    [SerializeField] private GameObject sceneControllerObject;
    [SerializeField] private SceneController sceneController;
    [SerializeField] private int sceneIndex;

    private bool isCanInteract = true;

    void Start () {
        sceneController = sceneControllerObject.GetComponent<SceneController>();
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

        StartCoroutine(sceneController.LoadScene(sceneIndex));
        isCanInteract = false;
    }

}
