using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{

    public Rigidbody2D playerRB;

    public TextMeshProUGUI TextSpeed;
    int MinSpeed = 100;

    public TextMeshProUGUI TextScore;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        TextScore.text = "Score : " + score;

        TextSpeed.text = MinSpeed + " KM/H";

        StartCoroutine(UpdateScore());

    }

    private void Update()
    {
        TextSpeed.text = MinSpeed + ((int)playerRB.velocity.y *10) + " KM/H";
    }
    IEnumerator UpdateScore()
    {
        while (true)
        {
            score++;
            TextScore.text = "Score : " + score;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
