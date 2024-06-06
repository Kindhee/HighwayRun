using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lines : MonoBehaviour
{
    public Rigidbody2D lineRB;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        lineRB.velocity = new Vector3(0, -speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        lineRB.velocity = new Vector3(0, -speed, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {
            Destroy(gameObject);
        }
    }
}
