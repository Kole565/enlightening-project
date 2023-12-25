using UnityEngine;


public class ParallaxController : MonoBehaviour {

    [SerializeField] private Transform cam;
    private Vector3 camStartPosition;

    private GameObject[] backgrounds;
    private Material[] materials;
    [Range(0.0005f, 0.002f)]
    public float parallaxSpeed;

    private float[] backSpeed;
    private float fartherst;
    private float distance;

    void Start () {
        camStartPosition = cam.position;

        int backCount = transform.childCount;
        materials = new Material[backCount];
        backSpeed = new float[backCount];
        backgrounds = new GameObject[backCount];

        for (int i = 0; i < backCount; i++) {
            backgrounds[i] = transform.GetChild(i).gameObject;
            materials[i] = backgrounds[i].GetComponent<Renderer>().material;
        }
        BackSpeedCalculate(backCount);
    }

    void BackSpeedCalculate (int backCount) {
        for (int i = 0; i < backCount; i++) {
            if (backgrounds[i].transform.position.z - cam.position.z > fartherst) {
                fartherst = backgrounds[i].transform.position.z - cam.position.z;
            }
        }

        for (int i = 0; i < backCount; i++) {
            backSpeed[i] = 1 - (backgrounds[i].transform.position.z - cam.position.z);
        }
    }

    private void LateUpdate () {
        distance = cam.position.x - camStartPosition.x;
        transform.position = new Vector3(cam.position.x, transform.position.y, 8);

        for (int i = 0; i < backgrounds.Length; i++) {
            float speed = backSpeed[i] * parallaxSpeed;
            materials[i].SetTextureOffset("_MainTex", new Vector2(-distance, 0) * speed);
        }

    }

}
