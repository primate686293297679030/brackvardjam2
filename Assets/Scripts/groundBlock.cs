using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class groundBlock : MonoBehaviour
{
    private ParticleSystem hit;
    [SerializeField]private GameObject hitVFX;
    private string name;  
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision should trigger destruction (e.g., explosion, character attack)
        if (collision.gameObject.CompareTag("bullet"))
        {
            Debug.Log("collision with bullet");

           Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the collision should trigger destruction (e.g., explosion, character attack)
        if (collider.gameObject.CompareTag("bullet"))
        {
            addScore(gameObject.name);
            Debug.Log("collision with bullet");
            Destroy(collider.gameObject);
            Destroy(this.gameObject);
            Instantiate(hitVFX, collider.transform.position, Quaternion.identity);

        }


    }

    public void addScore(string name)
    {
        if (name == "redGem(Clone)"|| name == "redGem")
        {
            playerStats.score += 5;
        }

        if (name == "blueGem(Clone)" || name == "blueGem")
        {
            playerStats.score += 10;

        }


    }

}
