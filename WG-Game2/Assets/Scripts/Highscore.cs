using UnityEngine.UI;
using UnityEngine;

public class Highscore : MonoBehaviour
{
    public GameObject Alien;
    public Text scoretext;
    alien alienScript;
    // Update is called once per frame

    void Start()
    {
        alienScript = Alien.GetComponent<alien>();
    }
    
    void Update()
    {
        scoretext.text = alienScript.highscore.ToString();
    }
}
