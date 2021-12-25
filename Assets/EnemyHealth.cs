using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Animator anim;
    public bool isElfDead;

    //When he dies disable colliders 
    public GameObject Head;
    public GameObject frontTopLeg;
    public GameObject frontBottomLeg;
    public GameObject BackTopLeg;
    public GameObject backBottomLeg;
    public GameObject blood;

    public Transform feet;
    public LayerMask groundLayers;
    public bool IsGrounded;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isElfDead == true)
        {

            anim.SetBool("isEnemyDead", isElfDead == true); // Death Animation

            GetComponent<Collider2D>().enabled = false; // Disables collider for santa rig and other body parts
            Head.GetComponent<Collider2D>().enabled = false;
            frontTopLeg.GetComponent<Collider2D>().enabled = false;
            frontBottomLeg.GetComponent<Collider2D>().enabled = false;
            BackTopLeg.GetComponent<Collider2D>().enabled = false;
            backBottomLeg.GetComponent<Collider2D>().enabled = false;

            
        }

        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        if (groundCheck != null)
        {
            IsGrounded = true;
        }

        if (groundCheck == null)
        {
            IsGrounded = false;
        }

        //Getting bomb script
        GameObject Bombrig = GameObject.FindGameObjectWithTag("Bomb");
        Bomb bomb = Bombrig.GetComponent<Bomb>();

        if(IsGrounded == false) // enemy is off the ground and a bomb has just exploded so this gotta mean that the enemy was in range
        {
            DeadElf();
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //Play death animation and delete all scripts involving firing bullets
            // Also delte body after a few seconds for game optimization

            isElfDead = true;
            blood = Instantiate(blood, collision.transform.position, Quaternion.identity);

            anim.SetBool("isEnemyDead", isElfDead == true); // Death Animation

            //Death Sound
            FindObjectOfType<AudioManager>().Play("PlayerDeath");

            GetComponent<Collider2D>().enabled = false; // Disables collider for santa rig and other body parts
            Head.GetComponent<Collider2D>().enabled = false;
            frontTopLeg.GetComponent<Collider2D>().enabled = false;
            frontBottomLeg.GetComponent<Collider2D>().enabled = false;
            BackTopLeg.GetComponent<Collider2D>().enabled = false;
            backBottomLeg.GetComponent<Collider2D>().enabled = false;

            Invoke("DeadElf", 0.7f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject Playerrig = GameObject.FindGameObjectWithTag("Player");
        PlayerMovement Playermove = Playerrig.GetComponent<PlayerMovement>();

        if (collision.gameObject.tag == "Player" && Playermove.isSliding == true)
        {
            isElfDead = true;
            blood = Instantiate(blood, collision.transform.position, Quaternion.identity);

            //Death Sound
            FindObjectOfType<AudioManager>().Play("PlayerDeath");

            anim.SetBool("isEnemyDead", isElfDead == true); // Death Animation

            GetComponent<Collider2D>().enabled = false; // Disables collider for santa rig and other body parts
            Head.GetComponent<Collider2D>().enabled = false;
            frontTopLeg.GetComponent<Collider2D>().enabled = false;
            frontBottomLeg.GetComponent<Collider2D>().enabled = false;
            BackTopLeg.GetComponent<Collider2D>().enabled = false;
            backBottomLeg.GetComponent<Collider2D>().enabled = false;

            Invoke("DeadElf", 0.7f);
        }

    }

    public void DeadElf()
    {
        Destroy(gameObject); // Removes elf and his body from scene 
    }
}
