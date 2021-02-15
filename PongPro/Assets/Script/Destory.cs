using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory : MonoBehaviour
{
    public float destoryTime = 2;
    private float temp;
    // Start is called before the first frame update
    void Start()
    {
        temp = destoryTime;
    }

    // Update is called once per frame
    void Update()
    {
        temp -= Time.deltaTime;
        if(temp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
