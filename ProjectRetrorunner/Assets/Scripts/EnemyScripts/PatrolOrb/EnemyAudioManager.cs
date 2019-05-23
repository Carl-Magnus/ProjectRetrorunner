using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudioManager : MonoBehaviour
{
    public AudioClip enemyHitByPlayer;
    private AudioSource audioSource;

    public void EnemyHitByPlayer()
    {
        audioSource.clip = enemyHitByPlayer;
        audioSource.Play();
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
