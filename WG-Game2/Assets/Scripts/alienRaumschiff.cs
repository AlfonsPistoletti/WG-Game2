using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienRaumschiff : MonoBehaviour
{
    Rigidbody2D rigid;
    public GameObject alien;
    public float speed;
    public float spawnIntervall;
    public float turnTimer;
    float lefttimer;
    float righttimer;
    bool goingleft;
    float spawntimer;
    public GameObject spawnschleim;
    public float xschleim;

    // Start is called before the first frame update
    void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();
        lefttimer = turnTimer;
        righttimer = turnTimer;

    }

    // Update is called once per frame
    void Update()
    {

        move();
        spawntimer = spawntimer + Time.deltaTime;
        if (spawntimer >= spawnIntervall)
        {
            Vector2 position = new Vector2(this.transform.position.x, this.transform.position.y - 1.5f);
            Vector2 positionschleim = new Vector3(this.transform.position.x, this.transform.position.y,xschleim);
            Instantiate(alien, position, this.transform.rotation);
            Instantiate(spawnschleim, position, this.transform.rotation);
            spawntimer = 0f;
        }


        
    }
    void move()
    {
        rigid.velocity = Vector2.left * speed;
        lefttimer = lefttimer + Time.deltaTime;
        if (lefttimer > turnTimer)
        {
            rigid.velocity = Vector2.right * speed;
            righttimer = righttimer + Time.deltaTime;
            if (righttimer > turnTimer)
            {
                lefttimer = 0f;
                righttimer = 0f;
            }
        }

    }
}   
