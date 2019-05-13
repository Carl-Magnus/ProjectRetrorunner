using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudioManager : MonoBehaviour
{
    public AudioClip hitByPlayer;
    private AudioSource audioSource;

    public void PlayerHitByPlayer()
    {
        audioSource.clip = hitByPlayer;
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
