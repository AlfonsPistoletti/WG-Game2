﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShooter : MonoBehaviour
{
    Touch touch;
    public GameObject raketenPrefab;
    public GameObject fadenkreuzPrefab;
    public float raketenSpeed = 2f;
    public float touchCooldown = 1f;
    float timer;

    public GameObject reloader1;
    public GameObject reloader2;
    public GameObject reloader2_copy;

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
            reloader1.SetActive(true);
            reloader2.SetActive(true);
            reloader2_copy.SetActive(false);

            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position) - this.transform.position;
                    touchPosition = touchPosition.normalized;
                    Debug.Log(touchPosition.ToString());


                    if (touchPosition.y >= 0.4)
                    {

                        Vector3 fadenkreuzPosition = Camera.main.ScreenToWorldPoint(touch.position);
                        fadenkreuzPosition.z = 0f;

                        GameObject fadenkreuz = Instantiate(fadenkreuzPrefab, fadenkreuzPosition, fadenkreuzPrefab.transform.rotation) as GameObject;
                        GameObject rakete = Instantiate(raketenPrefab, this.transform.position, raketenPrefab.transform.rotation) as GameObject;

                        Destroy(fadenkreuz, 1f);

                        Rigidbody2D raketenRigid = rakete.GetComponent<Rigidbody2D>();
                        raketenRigid.velocity = touchPosition * raketenSpeed;
                        timer = 0f;
                        reloader1.SetActive(false);
                        reloader2.SetActive(false);
                        reloader2_copy.SetActive(true);

                    }
                }

            }
        }
    }
}
