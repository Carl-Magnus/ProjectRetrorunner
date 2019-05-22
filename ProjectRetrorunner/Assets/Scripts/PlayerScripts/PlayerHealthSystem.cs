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
    private PlayerMovement playerMovement;
    private PlayerAudioManager playerAudioManager;
    // Start is called before the first frame update
    void Start()
    {
        damageCooldownReset = damageCooldown;
        playerMovement = gameObject.GetComponent<PlayerMovement>();
        playerAudioManager = gameObject.GetComponent<PlayerAudioManager>();
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
                playerAudioManager.PlayHitByEnemy();
            }
            else
            {
                playerIsDamaged = false;
            }
        }
    }

    public void PlayerGetRangedDamaged()
    {
        if (damageCooldown < 0)
        {
            health--;
            damageCooldown = damageCooldownReset;
            playerAudioManager.PlayHitByEnemy();
        }
        else
        {
            playerIsDamaged = false;
        }
    }
}