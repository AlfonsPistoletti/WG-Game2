﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int playerHealth = 5;
    public Text healthText;
    public GameObject healthExplosion;


    private void Update()
    {
        healthText.text = playerHealth.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Alien"))
        {
            //Debug.Log("Alien collided");
            Instantiate(healthExplosion, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(collision.gameObject);
            playerHealth = playerHealth - 1;
            RestartLevel();
        }

    }

    void RestartLevel()
    {
        if(playerHealth <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
