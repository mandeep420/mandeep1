using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upscore : MonoBehaviour
{

    public Text ScoreText;

    int score = 0;


    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        score++;
        Debug.Log("Score:" + score);
    }


}


