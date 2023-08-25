using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class depthMeter : MonoBehaviour
{
    public GameObject GroundLevel;
   
   public TextMeshProUGUI DepthText;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DepthText.text = "Depth: "+ getDepth().ToString();
    }



    float getDepth()
    {
        float depth;
        depth= player.transform.position.y - GroundLevel.transform.position.y;

        return depth;
    }
}
