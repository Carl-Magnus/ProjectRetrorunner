using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour
{
    private Transform cameraPosition;
    public Transform[] parallaxImages;

    private Vector3 previousCameraPosition; //Stores the camera's position from the previous frame.

    private float[] parallaxScales; // The proportion of the camera's movement to move the backgrounds by
    public float parallaxAmount = 1f; // How smooth the parallaxeffect is going to be. Keep it above 0!

    //Called before start, but after all GameObjects have been set up
    private void Awake()
    {
        cameraPosition = Camera.main.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        previousCameraPosition = cameraPosition.position;

        parallaxScales = new float[parallaxImages.Length];

        for (int i = 0; i < parallaxImages.Length; i++)
        {
            parallaxScales[i] = parallaxImages[i].position.z * -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < parallaxImages.Length; i++)
        {
            float parallax = (previousCameraPosition.x - cameraPosition.position.x) * parallaxScales[i];

            float backgroundTargetPositionX = parallaxImages[i].position.x + parallax;

            Vector3 backgroundTargetPosition = new Vector3(backgroundTargetPositionX, parallaxImages[i].position.y, parallaxImages[i].position.z);

            parallaxImages[i].position = Vector3.Lerp(parallaxImages[i].position, backgroundTargetPosition, parallaxAmount * Time.deltaTime);
        }

        previousCameraPosition = cameraPosition.position;
    }
}
