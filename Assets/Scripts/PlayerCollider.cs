using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public GameObject currentObject;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gun"))
        {
            currentObject = other.gameObject;
            Debug.Log("CurrentObject:" + currentObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        currentObject = null;
        Debug.Log("CurrentObject:" + currentObject);
    }
}
