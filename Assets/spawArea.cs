using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class spawArea : MonoBehaviour
{
    private BoxCollider2D bc;
    private Vector2 bcSize;
    private Vector2 Area;
    private int numberOfRows=100;
    private int numberOfCols=100;
    private int numberOfObjects=100;
    [SerializeField] private GameObject prefab;
    private float spacing = 0f;
    [SerializeField] private GameObject startPos;

   private Vector2 groundBlock;
    // Start is called before the first frame update
    void Start()
    { 
        Area.x= gameObject.transform.localScale.x;
        Area.y= gameObject.transform.localScale.y;
        groundBlock.y = prefab.transform.localScale.y;
        groundBlock.x = prefab.transform.localScale.x;

        var tmp = groundBlock.x / Area.x;
        var tmp2 = groundBlock.y / Area.y;

        var tmp3 = (100/tmp2-(100 % tmp2));
       // tmp3-
       // for(int i=0; i<tmp3 )Instantiate(prefab)

       //spacing = prefab.transform.localScale.x*4;

     // for (int i = 0; i < numberOfObjects; i++)
     // {
     //
     //     float xPos = i * spacing;
     //     Vector3 spawnPosition = transform.position + new Vector3(xPos, 0.0f, 0.0f);
     //  }
        bc =GetComponent<BoxCollider2D>();
        bcSize.y = bc.size.y;
        bcSize.x = bc.size.x;
        Debug.Log(bcSize.y);
        Debug.Log(bcSize.x);

        for (int row = 0; row < numberOfRows; row++)
        {
            for (int col = 0; col < numberOfCols; col++)
            {
                // Calculate the position for the instantiation
                Vector3 spawnPosition = startPos.transform.position + new Vector3(col +col* 0.15f, row+row*0.15f , 0.0f);

                // Instantiate the ground prefab at the calculated position
                Instantiate(prefab, spawnPosition, Quaternion.identity);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
