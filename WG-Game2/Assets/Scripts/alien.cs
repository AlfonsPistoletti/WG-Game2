using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alien : MonoBehaviour
{
    Rigidbody2D rigid;
    public float speed;
    public GameObject explosion;
    public GameObject explosion2;
    public GameObject health;

    // Use this for initialization
    void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = Vector2.down * speed;
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

        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            health.gameObject.GetComponent<Health>().LoseHealth();
            Destroy(this.gameObject);
        }

    }

}