using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PhotoesView : MonoBehaviour {

    [SerializeField] private Sprite[] photoes;
    [SerializeField] private Image activeImage;
    [SerializeField] private GameObject imagesPanel;

    private int index = 0;


    public void Start () {
        // imagesPanel.SetActive(true);
        Display();
    }

    void Display () {
        if (index < 0) {
            index = 0;
            return;
        }

        if (index >= photoes.Length) {
            End();
        }

        activeImage.sprite = photoes[index];
    }

    void End () {
        imagesPanel.SetActive(false);
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
