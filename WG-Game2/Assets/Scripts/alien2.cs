using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class alien2 : MonoBehaviour
{
    Rigidbody2D rigid;
    public float speed;
    public float sideSpeed;
    public GameObject explosion;
    public GameObject explosion2;
    public GameObject health;
    float timer;
    public float turnTimer;
    public bool isFacingRight = true;


    // Use this for initialization
    void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }

    void Move()
    {
        timer = timer + Time.deltaTime;
        rigid.velocity = Vector2.down * speed;

        if(timer >= turnTimer)
        {
            rigid.velocity = new Vector2(rigid.velocity.x * sideSpeed, rigid.velocity.y);
            timer = 0f;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rakete")
            || collision.gameObject.CompareTag("Player"))
        {
            Instantiate(explosion, this.transform.position, this.transform.rotation);
            Instantiate(explosion2, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            GameObject.FindGameObjectWithTag("ScoreCount").GetComponent<ScoreCount>().score += 2;

        }


    }

}