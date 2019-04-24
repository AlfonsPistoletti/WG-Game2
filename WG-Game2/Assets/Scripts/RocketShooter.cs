using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShooter : MonoBehaviour
{
    Touch touch;
    public GameObject raketenPrefab;
    public float raketenSpeed = 2f;
    public float touchCooldown = 1f;
    float timer;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Shoot();

    }

    void Shoot()
    {
        timer = timer + Time.deltaTime;

        if (timer >= touchCooldown)
        {

            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position) - this.transform.position;
                    touchPosition = touchPosition.normalized;
                    Debug.Log(touchPosition.ToString());

                    GameObject rakete = Instantiate(raketenPrefab, this.transform.position, raketenPrefab.transform.rotation) as GameObject;

                    Rigidbody2D raketenRigid = rakete.GetComponent<Rigidbody2D>();
                    raketenRigid.velocity = touchPosition * raketenSpeed;
                    timer = 0f;
                }

            }
        }
    }
}
