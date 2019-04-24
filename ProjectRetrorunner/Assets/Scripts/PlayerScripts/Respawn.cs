using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    public Transform respawnPoint;
    public Transform player;
    public HealthSystem healthSystem;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(healthSystem.health <= 0)
        {
            player.transform.position = respawnPoint.transform.position;
        }
    }
}
