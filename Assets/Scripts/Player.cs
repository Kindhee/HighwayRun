using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform playerTF;
    public Rigidbody2D playerRB;
    public float speed;

    public ParticleSystem particlesLeft;
    public ParticleSystem particlesRight;

    public SpriteRenderer BlinkerLeft;
    public SpriteRenderer BlinkerRight;

    string state;

    public float brakingRatio;

    private void Start()
    {
        StartCoroutine(Blinkers());
    }

    IEnumerator Blinkers()
    {
        while (true)
        {
            if (state == "right")
            {
                BlinkerRight.color = Color.yellow;

                yield return new WaitForSeconds(0.1f);

                BlinkerRight.color = Color.white;

                yield return new WaitForSeconds(0.1f);
            }

            else if (state == "left")
            {
                BlinkerLeft.color = Color.yellow;

                yield return new WaitForSeconds(0.1f);

                BlinkerLeft.color = Color.white;

                yield return new WaitForSeconds(0.1f);
            }
            else if (state == "braking")
            {
                BlinkerLeft.color = Color.red;
                BlinkerRight.color = Color.red;

                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                BlinkerLeft.color = Color.white;
                BlinkerRight.color = Color.white;

                yield return new WaitForSeconds(0.1f);
            }


        }
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal
        if(Input.GetKey(KeyCode.A))
        {
            state = "clear";
            state = "left";

            playerRB.velocity = new Vector2(playerRB.velocity.x - (speed * Time.deltaTime), playerRB.velocity.y);

        } else if (Input.GetKey(KeyCode.D))
        {
            state = "clear";
            state = "right";

            playerRB.velocity = new Vector2(playerRB.velocity.x + (speed * Time.deltaTime), playerRB.velocity.y);
        }
        else
        {
            state = "clear";
        }
        // --

        // Vertical
        if (Input.GetKey(KeyCode.W))
        {
            state = "clear";

            playerRB.velocity = new Vector2(playerRB.velocity.x, playerRB.velocity.y + (speed * Time.deltaTime));
            particlesLeft.Play();
            particlesRight.Play();

        }
        if (Input.GetKey(KeyCode.S))
        {
            state = "braking";

            if(playerRB.velocity.y > 0)
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x, playerRB.velocity.y - ((speed * brakingRatio) * Time.deltaTime));
            }
            playerRB.velocity = new Vector2(playerRB.velocity.x, playerRB.velocity.y - (speed * Time.deltaTime));

            particlesLeft.Stop();
            particlesRight.Stop();

            particlesLeft.Clear();
            particlesRight.Clear();

        }
        // --
    }
}
