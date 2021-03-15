using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManger : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;

    public TextMeshProUGUI highscoreText;
    private int highScore;

    public Image[] lifeSprites;

    private Color32 active = new Color(1, 1, 1);
    private Color32 inactive = new Color(1, 1, 0.5f);

    private static UIManger instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public static void UpdateLives(int l)
    {
        foreach (Image i in instance.lifeSprites)
            i.color = instance.inactive;
        for (int i = 0; i < l; i++)
        {
            instance.lifeSprites[i].color = instance.active;
        }
    }

    public static void UpdateScore( int s)
    {
        instance.score += s;
        instance.scoreText.text = instance.score.ToString("00,000");
    }

    public static void UpdateHighScore()
    {
        //10000
    }
}
