using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

        if (playerMovement.islookingLeft == true)
        {
            rb.velocity = transform.right * speed;
        }

        else
        {
            rb.velocity = -transform.right * speed;
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBody")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        else
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Elf" || collision.gameObject.tag == "ElfRig" )
        {
           
            Destroy(gameObject);
        }

    }
}

