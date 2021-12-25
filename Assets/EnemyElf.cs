using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyElf : MonoBehaviour
{
    public Transform castPoint;
    public float distance;

    public bool CanSee;
    public bool playerWasSeen;

    //Shooting
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float timer;
    public int waitingTime;

    void Update()
    {
        // RayCast and seeing player stuff
        var castDist = distance;

        Vector2 endPos = castPoint.position + Vector3.left * distance;
        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("Ground"));

        if (hit.collider != null) //Check if it hit anything in the ground layer
        {
            if (hit.collider.gameObject.CompareTag("Player")) // Hit player
            {
                //Play function which aims at player and starts firing repatedly
                Debug.DrawLine(castPoint.position, endPos, Color.green);
                CanSee = true;
                playerWasSeen = true;

                Shoot();

            }
            else if (hit.collider != null && playerWasSeen == false) // Hit something but NOT the player BUT IF PLAYER WAS HIT BEFORE IT WILL STILL SHOOT
            {

                Debug.DrawLine(castPoint.position, hit.point, Color.yellow);
                CanSee = false;
            }
        }
        else if (hit.collider == null && playerWasSeen == false)  //Didint hit nothing smh imagine...
        {
            Debug.DrawLine(castPoint.position, endPos, Color.blue);
            CanSee = false;
        }

        if (CanSee == true || playerWasSeen == true)
        {
            //Enemy begins shooting
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject Enemyrig = GameObject.FindGameObjectWithTag("ElfRig");
        EnemyHealth EnemyHealth = Enemyrig.GetComponent<EnemyHealth>();

        timer += Time.deltaTime;
        if (timer > waitingTime && EnemyHealth.isElfDead == false)
        {
            //Shooting Logic

            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            timer = 0;
        }

           
    }



}
