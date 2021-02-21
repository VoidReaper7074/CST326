using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameHub : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;

    public float countdown = 400;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        timeText.SetText("Time /n" + (int)countdown);
        scoreText.SetText("C: x" + score.ToString("D2")+ " \tTime \n\t\t" + (int)countdown);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                GameObject obj = objectHit.gameObject;
                if(obj.name == "QuestionBox(Clone)")
                {
                    score++;
                }
                //Destroy(obj);
            }
        }
        
    }
}
