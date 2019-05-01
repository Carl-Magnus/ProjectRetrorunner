using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    float time = 0;
    public float width, height;
    public float speed;

    private void Start()
    {
        width = transform.position.x;
        height = transform.position.y;
        transform.position = new Vector3(transform.position.x - width, transform.position.y - height, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        float x, y;
        time += Time.deltaTime * speed;
        x = Mathf.Cos(time) * width;
        y = Mathf.Sin(time) * height;

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
