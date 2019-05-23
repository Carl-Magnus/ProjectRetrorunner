using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CyberBlaster : MonoBehaviour
{
    public Transform firiringPoint;

    public GameObject cyberBlast;

    public Animator anim;

    private PlayerAudioManager playerAudioManager;

    private Image energyBar;

    public float blasterTimer;
    private float blasterTimerReset;

    // Start is called before the first frame update
    void Start()
    {
        energyBar = GameObject.FindGameObjectWithTag("EnergyBar").GetComponent<Image>();

        playerAudioManager = gameObject.GetComponent<PlayerAudioManager>();

        blasterTimerReset = blasterTimer;
    }

    // Update is called once per frame
    void Update()
    {
        blasterTimer += Time.deltaTime;

        if (blasterTimer < 2)
        {
            energyBar.fillAmount = blasterTimer / 2;
        }
    }

    public void Blast()
    {
        if (blasterTimer > 2)
        {
            playerAudioManager.PlayLaserShot();
            energyBar.fillAmount = 0f;
            Instantiate(cyberBlast, firiringPoint.position, firiringPoint.rotation);
            anim.SetTrigger("blast");
            blasterTimer = 0;
        }
    }    
}
