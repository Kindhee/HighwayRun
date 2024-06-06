using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cars : MonoBehaviour
{
    public Rigidbody2D carRB;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        carRB.velocity = new Vector3(0, -speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        carRB.velocity = new Vector3(0, -speed, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Finish")
        {
            Destroy(gameObject);
        }

        if(collision.tag == "Player")
        {
            SceneManager.LoadScene("HighwayArcade");
        }

        if (collision.tag == "Car")
        {
            if(collision.GetComponent<Cars>().speed < speed)
            {
                speed = collision.GetComponent<Cars>().speed;
            } else
            {
                collision.GetComponent<Cars>().speed = speed;
            }
        }
    }


}
