using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{

    public int health;
    private int lives;
    public int tries;
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
            player.SetActive(false);
            playerIsDead = true;
            SceneManager.LoadScene("GameOver");

            Respawn();
        }
    }
        
           

    public void Damaged()
    {
        lives -= 1;
        Debug.Log("Damaged");

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
