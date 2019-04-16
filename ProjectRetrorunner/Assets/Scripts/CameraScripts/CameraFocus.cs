using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    public Transform target;
    public Vector3 cameraOffset;

    void Start()
    {

    }

    void Update()
    {
        transform.position = target.position + cameraOffset;
    }
}
