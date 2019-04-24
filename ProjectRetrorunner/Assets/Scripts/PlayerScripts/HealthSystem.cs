using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    public int health;
    public Transform respawnPoint;
    public Transform player;
    private bool playerIsDead;


    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            playerIsDead = true;
            Respawn();
        }
    }

    public void Damaged()
    {
        health -= 1;

    }

    private void Respawn()
    {
        if(playerIsDead)
        {
            player.transform.position = respawnPoint.transform.position;
            playerIsDead = false;
        }
        
    }
}
