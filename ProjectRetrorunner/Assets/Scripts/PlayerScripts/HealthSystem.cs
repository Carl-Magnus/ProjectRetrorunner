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
    public float damageCooldown;
    private float damageCooldownReset;
    public GameObject player;
    private bool playerIsDead;
    public bool isDamaged;


    // Start is called before the first frame update
    void Start()
    {
        lives = health;
        damageCooldownReset = damageCooldown;
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

        damageCooldown -= Time.deltaTime;
    }
        
           

    public void Damaged()
    {
        lives -= 1;
        Debug.Log("Damaged");
        if(isDamaged)
        {

            if (damageCooldown < 0)
            {
                lives -= 1;
                damageCooldown = damageCooldownReset;
                Debug.Log("Damaged");
            }

            else
            {

                
                isDamaged = false;
            }
        }
    }
}
