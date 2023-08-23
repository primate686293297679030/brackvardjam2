using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class groundBlock : MonoBehaviour
{
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
            Debug.Log("owieiurorhhgoiouewhrg");
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

    }

}
