using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public Animator shakeAnim;


    public void CamShake()
    {
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            shakeAnim.SetTrigger("Shake");
            Handheld.Vibrate();
            Debug.Log("Shake 1");
        }

        if (rand == 1)
        {
            shakeAnim.SetTrigger("Shake2");
            Handheld.Vibrate();
            Debug.Log("Shake 2");
        }
    }
}
