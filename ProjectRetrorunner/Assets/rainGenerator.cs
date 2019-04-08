using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainGenerator : MonoBehaviour
{
    public GameObject rainDrop;

    private List<GameObject> rainDrops;

    private Random rnd;

    public float spawnTimer;
    private float resetTimer;

    // Start is called before the first frame update
    void Start()
    {
        rainDrops = new List<GameObject>();
        resetTimer = spawnTimer;
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        GenerateRain();
    }

    private void GenerateRain()
    {
        for (int i = 0; i < 150; i++)
        {
            if (spawnTimer <= 0)
            {
                rainDrop.transform.position = new Vector3(this.transform.position.x + Random.Range(-5, 5), this.transform.position.y, this.transform.position.z);
                Instantiate(rainDrop);
                rainDrops.Add(rainDrop);
                spawnTimer = resetTimer;
            }
        }
    }
}
