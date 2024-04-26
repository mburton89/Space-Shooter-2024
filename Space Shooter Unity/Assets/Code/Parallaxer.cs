using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxer : MonoBehaviour
{

    private Camera cam;
    Vector3 lastCamPosition;

    public float parallaxMultiplier = .01f;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 curentCamPosition = cam.transform.position;

        Vector3 adjustment = (cam.transform.position - lastCamPosition) * parallaxMultiplier;

        transform.position += adjustment;

        lastCamPosition = curentCamPosition;
    }
}
