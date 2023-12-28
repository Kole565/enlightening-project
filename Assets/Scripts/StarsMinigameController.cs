using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StarsMinigameController : MonoBehaviour {

    public float firstAxis, secondAxis, thirdAxis;
    public float firstAxisIncrement, secondAxisIncrement, thirdAxisIncrement;

    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private GameObject menuTrigger;
    [SerializeField]
    private RectTransform stars;
    [SerializeField]
    private Slider[] sliders;

    [SerializeField]
    private float maxError;

    [SerializeField]
    private float[] solution = new float[3];

    public bool isSolved = false;

    void Start () {
        System.Random rnd = new System.Random();

        firstAxisIncrement = rnd.Next(-25, 26) / 100f;
        secondAxisIncrement = rnd.Next(-180, 181);
        firstAxisIncrement = 0f;
        secondAxisIncrement = 0f;

        thirdAxisIncrement = 0f;

        UpdateSliders();
    }

    public void UpdateSliders () {
        firstAxis = sliders[0].value / 4f + 0.5f + firstAxisIncrement;
        secondAxis = sliders[1].value * 180 + secondAxisIncrement;
        thirdAxis = sliders[2].value + thirdAxisIncrement;

        stars.localScale = new Vector3(firstAxis + 0.5f * thirdAxis, firstAxis + 0.5f * thirdAxis, 1f);
        stars.rotation = Quaternion.Euler(0f, 0f, secondAxis + 90 * thirdAxis);
        
        if (CheckSolution(new Vector2 (firstAxis + 0.5f * thirdAxis, firstAxis + 0.5f * thirdAxis), secondAxis + 90 * thirdAxis) & !isSolved) {
            isSolved = true;
            End();
        }
        else {
            isSolved = false;
        }
    }

    void End () {
        menu.SetActive(false);
        StartCoroutine(Disappear());
    }

    IEnumerator Disappear () {
        for (float t = 1f; t > 0f; t -= (float) 1/128) {
            menuTrigger.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, t);
            yield return null;
        }
        menuTrigger.SetActive(false);
    }

    bool CheckSolution (Vector2 scale, float rotation) {
        if (Math.Abs(scale.x - solution[0]) < maxError & Math.Abs(scale.y - solution[1]) < maxError & (Math.Abs(rotation - solution[2]) / 90 < maxError)) {
            return true;
        }
        return false;
    }

}
