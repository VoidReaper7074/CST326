using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public ShipStats shipStats;

    public GameObject bulletPrefab;

    private Vector2 offScreenPos = new Vector2(0, 20f);
    private Vector2 startPos = new Vector2(0, -4f);

    private const float Max_Right = 13.7f;
    private const float Max_Left = -13.7f;

    private float speed = 5;
    private float cooldown = 0.5f;

    private bool isShooting;


    private void Start()
    {
        shipStats.currentHealth = shipStats.maxHealth;
        shipStats.currentLives = shipStats.maxLives;

        transform.position = startPos;

        UIManger.UpdateLives(shipStats.currentLives);
    }

    void Update()
	{
        if (Input.GetKey(KeyCode.A) && transform.position.x > Max_Left)

            transform.Translate(Vector2.left * Time.deltaTime * speed);

        if (Input.GetKey(KeyCode.D) && transform.position.x < Max_Right)

            transform.Translate(Vector2.right * Time.deltaTime * speed);

        if (Input.GetKey(KeyCode.Space) && !isShooting)
            StartCoroutine(Shoot());
    }

    private void TakeDamage()
    {
        shipStats.currentHealth--;
        if(shipStats.currentHealth <= 0)
        {
            shipStats.currentLives--;
            if(shipStats.currentLives <= 0)
            {
                Debug.Log("GAME OVER");
                //game over
            }
            else
            {
                //respawn Player
                StartCoroutine(Respawn());
            }
        }
    }

    private IEnumerator Shoot()
    {
        isShooting = true;
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(cooldown);
        isShooting = false;
    }
    private IEnumerator Respawn()
    {
        transform.position = offScreenPos;
        yield return new WaitForSeconds(2);

        shipStats.currentHealth = shipStats.maxHealth;
        transform.position = startPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("AlienBullet"))
        {
            Debug.Log("Player hit");
            TakeDamage();
            Destroy(collision.gameObject);
        }
    }
}
