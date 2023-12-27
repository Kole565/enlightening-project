using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TransitionController : MonoBehaviour {

    [SerializeField]
    private bool isStartTransitionActive, isEndTransitionActive;
    [SerializeField]
    private List<string> startTransitionText, endTransitionText;
    [SerializeField]
    private TMP_Text transitionTextField;

    private float fadeTime;
    [SerializeField]
    private float sentenceInterval;
    [SerializeField]
    private Image darkPanel;


    public IEnumerator StartTransitionCoroutine () {
        if (isStartTransitionActive) {
            darkPanel.gameObject.SetActive(true);
            yield return StartTransitionTextCoroutine();
        }
        else {
            darkPanel.gameObject.SetActive(false);
        }

        yield return null;
    }

    public IEnumerator EndTransitionCoroutine () {
        if (isEndTransitionActive) {
            darkPanel.gameObject.SetActive(true);
            yield return EndTransitionTextCoroutine();
        }
        else {
            darkPanel.gameObject.SetActive(false);
        }

        yield return null;
    }

    public IEnumerator StartTransitionTextCoroutine () {
        if (startTransitionText.Count > 0) {
            yield return DisplayText(startTransitionText);
        }

        yield return Brighten();
    }

    IEnumerator EndTransitionTextCoroutine () {
        yield return Darken();

        if (endTransitionText.Count > 0) {
            yield return DisplayText(endTransitionText);
        }
    }

    IEnumerator DisplayText (List<string> text) {
        for (int i = 0; i < text.Count; i++) {
            yield return DisplaySentence(text[i]);
            // yield return new WaitForSeconds(sentenceInterval);
            yield return UnDisplaySentence();
        }
    }

    IEnumerator DisplaySentence (string sentence) {
        // TODO: Make symbols appear sequently
        transitionTextField.text = sentence;

        for (float t = 0f; t < 1f; t += (float) 1/128) {
            transitionTextField.color = new Color(1f, 1f, 1f, t);
            yield return null;
        }

    }

    IEnumerator UnDisplaySentence () {
        // Make symbols disappear
        for (float t = 1f; t > 0f; t -= (float) 1/128) {
            transitionTextField.color = new Color(1f, 1f, 1f, t);
            yield return null;
        }

        transitionTextField.text = "";
    }

    IEnumerator Brighten () {
        for (float t = 1f; t > 0f; t -= (float) 1/128) {
            darkPanel.color = new Color(0f, 0f, 0f, t);
            yield return null;
        }
    }

    IEnumerator Darken () {
        for (float t = 0f; t < 1f; t += (float) 1/200) {
            darkPanel.color = new Color(0f, 0f, 0f, t);
            yield return null;
        }
    }


}
