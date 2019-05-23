using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryCheck : MonoBehaviour
{
    private BoxCollider2D player;
    private BoxCollider2D victoryBox;

    // Start is called before the first frame update
    void Start()
    {
        victoryBox = gameObject.GetComponent<BoxCollider2D>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            SceneManager.LoadScene("mainMenu");
        }
    }

}
