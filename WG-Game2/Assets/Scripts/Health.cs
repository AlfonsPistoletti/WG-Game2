using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public BoxCollider2D boden;
    public int playerHealth = 5;
    public Text healthText;

    private void Start()
    {
        boden = gameObject.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        healthText.text = playerHealth.ToString();
    }

    private void OnCollisionEnter2D(Collision2D boden)
    {
        if (boden.gameObject.CompareTag("Alien"))
        {
            Debug.Log("Alien collided");
        }

    }
}
