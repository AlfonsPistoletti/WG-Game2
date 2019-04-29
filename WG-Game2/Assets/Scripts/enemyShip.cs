using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyShip : MonoBehaviour
{
    Rigidbody2D rigid;
    public GameObject alien;
    public GameObject alien2;
    public float speed;
    private float spawnIntervall;
    private int spawnRandomness;
    float lefttimer;
    float righttimer;
    bool goingleft;
    float spawntimer;
    public GameObject spawnschleim;
    public GameObject explosion;
    public GameObject explosion2;
    public int health;

    [Header("Random Wert für Spawnzeit")]
    [Tooltip("Bildet einen Random-Wert zwischen minSpawnTime und maxSpawnTime")]
    public float minSpawnTime;
    [Tooltip("Bildet einen Random-Wert zwischen minSpawnTime und maxSpawnTime")]
    public float maxSpawnTime;

    [Header("Random Wert, wann ein starker kommt")]
    [Tooltip("Random Wert aus spawnRandMin und SpawnRandMax. Bei 0 spawnt ein starker Alien, bei allen anderen Zahlen ein normaler.")]
    public int spawnRandMin;
    [Tooltip("Random Wert aus spawnRandMin und SpawnRandMax. Bei 0 spawnt ein starker Alien, bei allen anderen Zahlen ein normaler.")]
    public int spawnRandMax;
    bool isMovingLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();
        spawnRandomness = spawnRandMax;
        Debug.Log(spawnRandomness);
    }

    // Update is called once per frame
    void Update()
    {

        MoveEnemy();
        CheckForWalls();
        Spawn();

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

    void Spawn()
    {
        spawntimer = spawntimer + Time.deltaTime;
        spawnIntervall = Random.Range(minSpawnTime, maxSpawnTime);
        if (spawntimer >= spawnIntervall && spawnRandomness > 0)
        {
            Vector2 position = new Vector2(this.transform.position.x, this.transform.position.y - 1.5f);
            Vector2 positionschleim = new Vector3(this.transform.position.x, this.transform.position.y);
            Instantiate(alien, position, this.transform.rotation);
            Instantiate(spawnschleim, position, this.transform.rotation);
            spawntimer = 0f;
            spawnRandomness = Random.Range(spawnRandMin, spawnRandMax);
        }
        if (spawntimer >= spawnIntervall && spawnRandomness == 0)
        {
            Vector2 position = new Vector2(this.transform.position.x, this.transform.position.y - 1.5f);
            Vector2 positionschleim = new Vector3(this.transform.position.x, this.transform.position.y);
            Instantiate(alien2, position, this.transform.rotation);
            Instantiate(spawnschleim, position, this.transform.rotation);
            spawntimer = 0f;
            spawnRandomness = Random.Range(spawnRandMin, spawnRandMax);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rakete"))
        {
            health = health - 1;
            Debug.Log(health);
            Instantiate(explosion, this.transform.position, this.transform.rotation);
            Instantiate(explosion2, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(collision.gameObject);
            if (health <= 0)
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

     
