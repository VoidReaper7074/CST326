using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    private float speed = 15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
    }

    // Called when the Game Object isn't visible
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Alien"))
        {
            //kill alien
            collision.gameObject.GetComponent<Alien>().Kill();
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("AlienBullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
