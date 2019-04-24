using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{

    public int playerHealth = 5;



    public void LoseHealth()
    {
        playerHealth = playerHealth - 1;

        if(playerHealth <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
