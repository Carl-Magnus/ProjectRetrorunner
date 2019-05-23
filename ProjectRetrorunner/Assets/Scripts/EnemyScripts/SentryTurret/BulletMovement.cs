using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed;
    public float lifeTime;

    //public GameObject destroyEffect;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBullet", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * -speed * Time.deltaTime);
    }

    private void DestroyBullet()
    {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            PlayerHealthSystem player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthSystem>();

            player.playerIsDamaged = true;
            player.PlayerGetRangedDamaged();

            DestroyBullet();
        }
        else if (collision.collider.tag == "Enemy")
        {
            Physics2D.IgnoreLayerCollision(13, 13);
        }
        else if (collision.collider.tag == "Sentry")
        {
            Physics2D.IgnoreLayerCollision(13, 13);
        }
        else
        {
            DestroyBullet();
        }
    }
}
