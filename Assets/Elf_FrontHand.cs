using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elf_FrontHand : MonoBehaviour
{
    public GameObject Player;

    private void Start()
    {

    }

    private void Update()
    {
        // Make hand aim at player
        Vector3 dir = Player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);

        GameObject Enemyrig = GameObject.FindGameObjectWithTag("Elf");
        EnemyElf EnemyMovement = Enemyrig.GetComponent<EnemyElf>();
        EnemyHealth EnemyHealth = Enemyrig.GetComponent<EnemyHealth>();
    }

    /*  (EnemyHealth.isElfDead == false && EnemyMovement.CanSee == true)
        {
            Debug.Log("Aim at player");



            //Vector3 difference = Player.transform.position - transform.position;
            //float rotationZ = Mathf.Atan2(difference.y, difference.x);
            //transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
      
        } */


}

