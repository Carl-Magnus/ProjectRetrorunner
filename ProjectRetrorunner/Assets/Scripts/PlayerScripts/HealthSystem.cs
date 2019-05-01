using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{

    public int health;
    private int lives;
    public int tries;
    private int attempts;
    public GameObject respawnPoint;
    public GameObject player;
    private bool playerIsDead;


    // Start is called before the first frame update
    void Start()
    {
        lives = health;
        attempts = tries;
    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0)
        {
            player.SetActive(false);
            attempts--;
            playerIsDead = true;
            Respawn();
        }

        if(attempts <= 0)
        {
            SceneManager.LoadScene("GameOver");
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
            playerIsDead = false;
            player.SetActive(true);
            player.transform.position = respawnPoint.transform.position;
            lives = health;
        }
        
    }
}
