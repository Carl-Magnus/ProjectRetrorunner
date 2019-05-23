using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private PlayerAudioManager playerAudioManager;

    private Image healthBar;

    public int health;
    private int maxHealth;

    public float damageCooldown;
    private float damageCooldownReset;
    private float maxFillAmount;


    public bool playerIsDamaged;

    // Start is called before the first frame update
    void Start()
    {
        damageCooldownReset = damageCooldown;
        playerMovement = GetComponent<PlayerMovement>();
        playerAudioManager = GetComponent<PlayerAudioManager>();
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Image>();

        maxFillAmount = healthBar.fillAmount;
        maxHealth = health;
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

                healthBar.fillAmount -= maxFillAmount / maxHealth;

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

            healthBar.fillAmount -= maxFillAmount / maxHealth;
        }
        else
        {
            playerIsDamaged = false;
        }
    }
}