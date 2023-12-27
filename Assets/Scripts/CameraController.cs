using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour {

    private new Camera camera;

    [SerializeField] private float zoom;

    void Start () {
        camera = GetComponent<Camera>();
    }

    void Update () {
        camera.orthographicSize = zoom;
    }

}
