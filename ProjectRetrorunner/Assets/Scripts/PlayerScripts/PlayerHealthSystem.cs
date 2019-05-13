using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthSystem : MonoBehaviour
{
    public int health;
    public float damageCooldown;
    private float damageCooldownReset;
    public bool playerIsDamaged;
    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        damageCooldownReset = damageCooldown;
        playerMovement = FindObjectOfType<PlayerMovement>();
    }
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        damageCooldown -= Time.deltaTime;
    }

    public void PlayerGetDamaged(Vector2 direction)
    {
        if (playerIsDamaged)
        {
            if (damageCooldown < 0)
            {
                health--;
                damageCooldown = damageCooldownReset;
                playerMovement.KnockBack(direction);
                Debug.Log("Damaged");
            }
            else
            {
                playerIsDamaged = false;
            }
        }
    }
}