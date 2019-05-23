using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private PlayerAudioManager playerAudioManager;

    private Transform playerTransform;

    private Image healthBar;

    private Transform resetPoint;

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
        playerMovement = gameObject.GetComponent<PlayerMovement>();
        playerAudioManager = gameObject.GetComponent<PlayerAudioManager>();
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Image>();
        resetPoint = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Transform>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        maxFillAmount = healthBar.fillAmount;
        maxHealth = health;
    }
    // Update is called once per frame
    void Update()
    {
        OutOfMap();

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

    private void OutOfMap()
    {
        if (playerTransform.transform.position.y < -10)
        {
            health--;
            healthBar.fillAmount -= maxFillAmount / maxHealth;
            playerTransform.transform.position = resetPoint.transform.position;
            playerAudioManager.PlayHitByEnemy();
        }
    }
}