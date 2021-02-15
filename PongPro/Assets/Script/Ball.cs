using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    private Vector3 direction;
    public float speed;
    [SerializeField]
    private int playerOneScore;
    [SerializeField]
    private int playerTwoScore;

    public Vector3 spawnPoint;

    public GameObject goalEffect;

    public Text playerOneText;
    public Text playerTwoText;

    // Start is called before the first frame update
    void Start()
    {
        playerOneScore = 0;
        playerTwoScore = 0;
        this.direction = new Vector3(1f, 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += direction * speed;

        playerOneText.text = playerOneScore.ToString();
        playerTwoText.text = playerTwoScore.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;
        direction = Vector3.Reflect(direction, normal);

        if(collision.gameObject.name == "WestWall")
        {
            playerTwoScore++;
            Instantiate(goalEffect, this.transform.position, Quaternion.identity);
            transform.position = spawnPoint;
        }
        if(collision.gameObject.name == "EastWall")
        {
            playerOneScore++;
            Instantiate(goalEffect, this.transform.position, Quaternion.identity);
            transform.position = spawnPoint;
        }
        if(collision.gameObject.name == "Player1")
        {
            var newSpeed = speed + .002f;
            speed = newSpeed;
        }
        if (collision.gameObject.name == "Player2")
        {
            var newSpeed = speed + .002f;
            speed = newSpeed;
        }
    }
}
