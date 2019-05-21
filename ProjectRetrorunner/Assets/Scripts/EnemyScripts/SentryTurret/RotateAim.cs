using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAim : MonoBehaviour
{
    public GameObject bullet;

    private Rigidbody2D body;

    private Transform playerPosition;
    public Transform canonPosition;
    public Transform shotPoint;

    public float rotationOffset;
    public float bulletOffSet;
    public float startTimeBetweenShots;
    private float timeBetweenShots;

    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        playerPosition = GameObject.FindWithTag("Player").transform;
        timeBetweenShots = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        RotateCanon();
        FireCanon();
    }

    private void RotateCanon()
    {
        Vector3 differance = canonPosition.position - playerPosition.position;
        float rotationZ = Mathf.Atan2(differance.y, differance.x) * Mathf.Rad2Deg;
        canonPosition.rotation = Quaternion.Euler(0f, 0f, rotationZ + rotationOffset);
    }

    private void FireCanon()
    {
        if (timeBetweenShots <= 0)
        {
            Instantiate(bullet, shotPoint.position, canonPosition.transform.rotation);
            timeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }
}
