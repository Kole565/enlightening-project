using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PhotoesView : MonoBehaviour {

    [SerializeField] private Sprite[] photoes;
    [SerializeField] private Image activeImage;
    [SerializeField] private GameObject imagesPanel;

    [SerializeField] private SceneController sceneController;

    private int index = 0;


    public void Start () {
        Display();
    }

    void Display () {
        if (index < 0) {
            index = 0;
            return;
        }

        if (index >= photoes.Length) {
            End();
            return;
        }

        activeImage.sprite = photoes[index];
    }

    void End () {
        imagesPanel.SetActive(false);
        StartCoroutine(sceneController.LoadNextScene());
    }

    public void DisplayNext () {
        index++;
        Display();
    }

    public void DisplayPrevious () {
        index--;
        Display();
    }
    
}
