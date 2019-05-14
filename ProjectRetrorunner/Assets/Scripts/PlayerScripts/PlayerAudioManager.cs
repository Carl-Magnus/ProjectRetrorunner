using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    public AudioClip laserShot;
    public AudioClip hitByEnemy;
    public AudioClip attackSound;
    public AudioClip dashSound;
    private AudioSource audioSource;

    public void PlayLaserShot()
    {
        audioSource.clip = laserShot;
        audioSource.Play();
    }

    public void PlayAttackSound()
    {
        audioSource.clip = attackSound;
        audioSource.Play();
    }

    public void PlayDashSound()
    {
        audioSource.clip = dashSound;
        audioSource.Play();
    }

    public void PlayHitByEnemy()
    {
        audioSource.clip = hitByEnemy;
        audioSource.Play();
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
