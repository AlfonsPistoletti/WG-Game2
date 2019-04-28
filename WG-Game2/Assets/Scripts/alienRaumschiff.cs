using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
   
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
    public GameObject explosion;
    public GameObject explosion2;
    public float minSpawn;
    public float maxSpawn;
    public float health;

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

        Move();
        spawntimer = spawntimer + Time.deltaTime;
        spawnIntervall = Random.Range(minSpawn, maxSpawn);
        if (spawntimer >= spawnIntervall)
        {
            Vector2 position = new Vector2(this.transform.position.x, this.transform.position.y - 1.5f);
            Vector2 positionschleim = new Vector3(this.transform.position.x, this.transform.position.y);
            Instantiate(alien, position, this.transform.rotation);
            Instantiate(spawnschleim, position, this.transform.rotation);
            spawntimer = 0f;
           
        }


        
    }
    void Move()
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Rakete"))
        {
            health = health - 1;
            Debug.Log(health);
            Instantiate(explosion, this.transform.position, this.transform.rotation);
            Instantiate(explosion2, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(collision.gameObject);
            if(health <= 0)
            {
                GameObject.FindGameObjectWithTag("ScoreCount").GetComponent<ScoreCount>().score += 5;
                PlayerPrefs.SetInt("Highscore", GameObject.FindGameObjectWithTag("ScoreCount").GetComponent<ScoreCount>().score);
                SceneManager.LoadScene(0);
            }
        }
    }
}   
