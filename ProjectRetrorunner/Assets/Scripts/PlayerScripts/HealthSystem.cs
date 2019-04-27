using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    public int health;
    private int lives;
    public GameObject respawnPoint;
    public GameObject player;
    private bool playerIsDead;


    // Start is called before the first frame update
    void Start()
    {
        lives = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0)
        {
            playerIsDead = true;
            player.SetActive(false);
            Respawn();
        }
    }

    public void Damaged()
    {
        lives -= 1;

    }

    private void Respawn()
    {
        if(playerIsDead)
        {
            
            player.SetActive(true);
            player.transform.position = respawnPoint.transform.position;
            playerIsDead = false;
            lives = health;
        }
        
    }
}
