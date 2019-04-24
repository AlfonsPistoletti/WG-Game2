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
            Vector3 randomPosition = new Vector3(this.transform.position.x,
                                     this.transform.position.y + Random.Range(-3f, 3f), 0);
            Instantiate(enemy, randomPosition, enemy.transform.rotation);
            timer = 0f;
        }

    }
}