using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 originalPos = transform.localPosition;
        float x = Random.Range(-0.1f, 0.1f);
        float y = Random.Range(-0.1f, 0.1f);

        transform.localPosition = new Vector3(x, y, originalPos.z);
    }
}
