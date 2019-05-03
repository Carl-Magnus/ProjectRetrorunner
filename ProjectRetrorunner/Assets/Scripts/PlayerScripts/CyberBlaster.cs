using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyberBlaster : MonoBehaviour
{
    public Transform firiringPoint;

    public GameObject cyberBlast;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Blast()
    {
        Instantiate(cyberBlast, firiringPoint.position, firiringPoint.rotation);
        anim.SetTrigger("blast");
    }    
}
