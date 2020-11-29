using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private float enemySpeed;
    private float outOfBounds = -47;

    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        enemySpeed = Random.Range(10, 15);                                                              //Give the enemies a random speed value

        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();            //Get a reference to the playercontroller Script
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * enemySpeed);         //Enemy movement

        if (transform.position.x < outOfBounds)
        {
            Destroy(gameObject);                                                    //Destroy when out of bounds
        }

        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * enemySpeed);
        }

        if (playerControllerScript.gameOver == true)
        {
            enemySpeed = 0f;        
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))                                         //Destroy when hits object with the tag "Projectile"
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
