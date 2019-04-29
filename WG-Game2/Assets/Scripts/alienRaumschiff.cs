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
    float spawntimer;
    public GameObject spawnschleim;
    public GameObject explosion;
    public GameObject explosion2;
    public float minSpawn;
    public float maxSpawn;
    public float health;
    bool isMovingLeft = true;



    // Start is called before the first frame update
    void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        MoveEnemy();
        CheckForWalls();

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


    void CheckForWalls()
    {
        if (isMovingLeft == true)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(this.transform.position,
                                    Vector2.left, 2.3f);
            foreach (RaycastHit2D h in hits)
            {
                if (h.transform.CompareTag("Seite") == true)
                {
                    isMovingLeft = false;
                }
            }
        }
        else
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(this.transform.position,
                                    Vector2.right, 2.3f);
            foreach (RaycastHit2D h in hits)
            {
                if (h.transform.CompareTag("Seite") == true)
                {
                    isMovingLeft = true;
                }
            }
        }
    }

    void MoveEnemy()
    {
        if (isMovingLeft == true)
        {
            rigid.velocity = Vector2.left * speed;
        }
        else
        {
            rigid.velocity = Vector2.right * speed;
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
                if (GameObject.FindGameObjectWithTag("ScoreCount").GetComponent<ScoreCount>().score > PlayerPrefs.GetInt("Highscore"))
                {
                    PlayerPrefs.SetInt("Highscore", GameObject.FindGameObjectWithTag("ScoreCount").GetComponent<ScoreCount>().score);
                }
                SceneManager.LoadScene(0);
            }
        }
    }

    
}   
