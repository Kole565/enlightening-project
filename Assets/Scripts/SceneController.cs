using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour {

    private TransitionController transitionController;
    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private bool isCutScene;
    [SerializeField]
    private float cutSceneDuration;


    void Start () {
        transitionController = GetComponent<TransitionController>();

        if (isCutScene) {
            StartCoroutine(LoadCutScene());
            return;
        }

        // playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        StartCoroutine(LoadCurrentScene());
    }

    IEnumerator LoadCurrentScene () {
        playerController.isActive = false;

        yield return transitionController.StartTransitionCoroutine();

        playerController.isActive = true;
    }

    IEnumerator LoadCutScene () {
        yield return transitionController.StartTransitionCoroutine();
        yield return new WaitForSeconds(cutSceneDuration);
        yield return LoadNextScene();
    }

    public IEnumerator LoadNextScene () {
        yield return transitionController.EndTransitionCoroutine();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
