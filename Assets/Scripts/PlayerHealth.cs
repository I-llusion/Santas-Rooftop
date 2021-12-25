using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Animator anim;
    public bool playerDied;

    public GameObject playerdiedUi;

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
        if (collision.gameObject.tag == "EnemyBullet")
        {
            //Whatever I want to do when player dies, slo-mo, game ended etc.
            playerDied = true;

            anim.SetBool("isDead", playerDied == true);

            //Death Sound
            FindObjectOfType<AudioManager>().Play("PlayerDeath");

            Invoke("ShowEndScreen", 1f);
        }

        //Player hit the death boundry
        if (collision.gameObject.tag == "DeathBoundry")
        {
            playerDied = true;
            Debug.Log("Player out of bounds");

            //Death Sound
            FindObjectOfType<AudioManager>().Play("PlayerDeath");

            ShowEndScreen();
        }
    }

    public void ShowEndScreen()
    {
        //Show message (u died) or something idk
        playerDied = false;
        Debug.Log("Show end screen");

        Destroy(GetComponent<FrontHand>());
        Destroy(GetComponent<PlayerMovement>());
        Destroy(GetComponent<Weapon>());

        playerdiedUi.SetActive(true);
    }
}
