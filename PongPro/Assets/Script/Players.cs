using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    public enum ePlayer
    {
        Left,
        Right,
    }

    public float speed = 15f;
    public ePlayer player;

    // Update is called once per frame
    void Update()
    {
        float inputspeed = 0f;
        if (player == ePlayer.Left)
        {
            inputspeed = Input.GetAxisRaw("Player1");
        }
        else if (player == ePlayer.Right)
        {
            inputspeed = Input.GetAxisRaw("Player2");
        }
        transform.position += new Vector3(0f, 0f, inputspeed * speed * Time.deltaTime);
    }
}

