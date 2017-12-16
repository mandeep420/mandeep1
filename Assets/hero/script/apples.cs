using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class apples : MonoBehaviour
{


    public Text ScoreText;

    static int score = 0;



    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);

            score++;
            ScoreText.text = "APPLES: " + score;


        }
    }
}


