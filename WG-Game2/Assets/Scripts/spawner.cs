using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{

    public GameObject enemy;
    public float spawnIntervall = 1f;
    float timer;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        timer = timer + Time.deltaTime;

        if (timer >= spawnIntervall)
        {
            Vector3 randomPosition = new Vector3(this.transform.position.x + Random.Range(-4f, 4f),
                                     this.transform.position.y, 0);
            Instantiate(enemy, randomPosition, enemy.transform.rotation);
            timer = 0f;
        }

    }
}