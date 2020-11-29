using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float playerSpeed = 15;

    private float xRange = 45;
    private float zRange = 15;

    public GameObject projectilePrefab;

    public bool gameOver = false;

    public bool hasPowerup = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");                                          //Player Movement
        verticalInput = Input.GetAxis("Vertical");                                              //Player Movement

        if (gameOver == false)
        {
            transform.Translate(Vector3.right * verticalInput * Time.deltaTime * playerSpeed);      //Player Movement
            transform.Translate(Vector3.forward * horizontalInput * Time.deltaTime * playerSpeed);  //Player Movement
        }

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);  //Keeping Player inbounds
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);   //Keeping Player inbounds
        }

        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);  //Keeping Player inbounds
        }

        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);   //Keeping Player inbounds
        }

        if (Input.GetKeyDown(KeyCode.Space) && hasPowerup == true)
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);  //Launch the projectile
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))                                         //Destroy the Powerup when hits object with the tag "Powerup"
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdownRoutine());
        }

        if (other.gameObject.CompareTag("Enemy"))                               //"End" the game when you hit an enemy, set the boolean to true and add a Game Over to the debug log
        {
            gameOver = true;
            Debug.Log("Game Over!");
        }
    }

    IEnumerator PowerUpCountdownRoutine()
    {
        if (gameOver == false)
        {
            yield return new WaitForSeconds(7);
            hasPowerup = false;
        }
    }
}
