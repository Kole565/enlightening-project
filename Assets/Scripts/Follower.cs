using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Follower : MonoBehaviour {
    
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    public Transform followTo;

    void Update () {
        transform.position = followTo.position + offset;
    }

}
