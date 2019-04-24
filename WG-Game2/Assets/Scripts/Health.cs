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


    public void LoseHealth()
    {
        playerHealth = playerHealth - 1;

    }
}
