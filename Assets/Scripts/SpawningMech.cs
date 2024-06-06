using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawningMech : MonoBehaviour
{
    public List<GameObject> cars;

    int randomLane;
    int randomLaneDiff;

    int randomNumber;
    int randomCar;
    int alreadyChose;

    Vector3[] pos = { new Vector3(-2.8f, 10, 0), new Vector3(0, 10, 0), new Vector3(2.8f, 10, 0) };

    void Start()
    {
        StartCoroutine(SpawnCars());
    }

    IEnumerator SpawnCars()
    {
        while (true)
        {
            randomLane = Random.Range(0, 3);
            randomCar = Random.Range(0, 4);
            alreadyChose = randomCar;
            Instantiate(cars[randomCar], pos[randomLane], cars[randomCar].gameObject.transform.rotation);

            randomNumber = Random.Range(3, 8);
            if(randomNumber == 7)
            {
                randomLaneDiff = Random.Range(0, 3);
                while (randomLaneDiff == randomLane) {
                    randomLaneDiff = Random.Range(0, 3);
                }

                randomCar = Random.Range(0, 4);
                while (randomCar == alreadyChose)
                {
                    randomCar = Random.Range(0, 4);
                }
                Instantiate(cars[randomCar], pos[randomLaneDiff], cars[randomCar].gameObject.transform.rotation);
            }


            yield return new WaitForSeconds(2);
        }
    }
}
