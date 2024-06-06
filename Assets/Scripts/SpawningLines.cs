using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningLines : MonoBehaviour
{
    public GameObject line;

    Vector2[] pos = { new Vector3(-1.407f, 9.963f, 0), new Vector3(1.344f, 9.963f, 0)};

    void Start()
    {
        StartCoroutine(SpawnLines());
    }

    IEnumerator SpawnLines()
    {
        while (true)
        {
           
            Instantiate(line, pos[0], line.transform.rotation);
            Instantiate(line, pos[1], line.transform.rotation);
            yield return new WaitForSeconds(0.26f);
        }
    }
}
