using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IceController : MonoBehaviour {

    [SerializeField]
    public SpriteRenderer ice;
    [SerializeField]
    public float icingDuration;

    public void ShowIce () {
        StartCoroutine(IceAppear());
    }

    IEnumerator IceAppear() {
        for (float t = 0.0f; t < 1.0f; t += (float) 1/255) {
            ice.color = new Color(1f, 1f, 1f, t);
            yield return new WaitForSeconds(icingDuration / 255);
        }
    }

}
