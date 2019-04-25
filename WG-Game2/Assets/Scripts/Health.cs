using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public int playerHealth = 5;
    public Text healthText;



    private void Update()
    {
        healthText.text = playerHealth.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Alien"))
        {
            playerHealth = playerHealth -1;
            Destroy(collision.gameObject);
        }
    }
}
