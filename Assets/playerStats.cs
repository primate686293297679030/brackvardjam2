using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI debugText;
    public TextMeshProUGUI scoreText;
    public static int health;
    public static int score;
    public GameObject player;
    private PlayerController pc;
    void Start()
    {
       pc= player.GetComponent<PlayerController>();
       
    }

    // Update is called once per frame
    void Update()
    {
       
        //debugText.text ="PlayerCollider: " + pc.playerCollider.currentObject.ToString();
        scoreText.text = "Score: "+ score.ToString();
    }

   
}
