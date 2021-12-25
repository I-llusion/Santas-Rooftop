using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = -transform.right * speed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject); // Destroy Bullet

        //Play particle system on point of contact

        //Put out a debug of what was shot, enemy or player

    }
}
