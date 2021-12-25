using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float fieldofImpact;
    public float force;
    public LayerMask LayerToHit;

    public float killZone;

    public ParticleSystem explosion;
    public bool isExploding;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "EnemyBullet")
        {
            explode();
            explosion.Play();
            FindObjectOfType<AudioManager>().Play("Explosion");
            Invoke("DestroyGift", 0.5f);
        }
    }

    public void explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldofImpact, LayerToHit);

        foreach (Collider2D obj in objects)
        {
           
            if (obj.GetComponent<Rigidbody2D>() != null)
            {
                
                Vector2 direction = obj.transform.position - transform.position;
                obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
            }
        }


        //Kill circle
        Collider2D[] i = Physics2D.OverlapCircleAll(transform.position, killZone, LayerToHit);

        foreach (Collider2D obv in i)
        {
            if (obv.gameObject.tag == "Player")
            {
                GameObject Playerrig = GameObject.FindGameObjectWithTag("Player");
                PlayerHealth Playermove = Playerrig.GetComponent<PlayerHealth>();
                Playermove.ShowEndScreen();
                Debug.Log("player in kill zone");
              

                //Death Sound
                FindObjectOfType<AudioManager>().Play("PlayerDeath");
            }

        }


    }

    public void DestroyGift()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldofImpact);
        Gizmos.DrawWireSphere(transform.position, killZone);
    }
}
