using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointer : MonoBehaviour
{
    [SerializeField] private Camera cam;

    private Vector3 mouseWorld;
   [SerializeField] private GameObject pointerPrefab;
    private Vector3 mousePosition;

    private GameObject pointerguy;

    private Vector3 mouseRay;
    // Start is called before the first frame update
    void Start()
    {
 

    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        mouseWorld = cam.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, cam.nearClipPlane));
       
        if (Input.GetMouseButtonDown(0))
        {

            pointerguy=Instantiate(pointerPrefab, mouseWorld, Quaternion.identity);
        }

        if (Input.GetMouseButton(0))
        {
            pointerguy.transform.position = Vector3.MoveTowards(pointerguy.transform.position, mouseWorld,1);

        }
            if (Input.GetMouseButtonUp(0))
        {
            Destroy(pointerguy);

        }

    }
}
