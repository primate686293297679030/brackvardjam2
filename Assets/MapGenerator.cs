using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapGenerator : MonoBehaviour
{
    public int width = 100;
    public int height = 100;
    public float scale = 10f;

    public GameObject prefab;
    public GameObject Gemprefab;
    public GameObject redGemPrefab;

    private int[,] _mapMatrix;
    
    // Start is called before the first frame update
    void Start()
    {
        
      
       GenerateMatrix();
       SpawnMap();
    }

    private void SpawnMap()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (y < 30 && Random.Range(1, 10) == 1 && _mapMatrix[y, x] == 1&&y>20&&x<80&&x>20)
                {
                    Instantiate(Gemprefab, new Vector3(x * Gemprefab.GetComponent<Renderer>().bounds.size.x, y * Gemprefab.GetComponent<Renderer>().bounds.size.y), Quaternion.identity);
                }
                else if (y > 70&& y<80  && _mapMatrix[y, x] == 1&&Random.Range(1, 10) == 1&& x<90&&x>10)
                {
                    Instantiate(redGemPrefab, new Vector3(x * redGemPrefab.GetComponent<Renderer>().bounds.size.x, y * redGemPrefab.GetComponent<Renderer>().bounds.size.y), Quaternion.identity);

                }
                else if (_mapMatrix[y, x] == 1)
                {
                    Instantiate(prefab, new Vector3(x * prefab.GetComponent<Renderer>().bounds.size.x, y * prefab.GetComponent<Renderer>().bounds.size.y), Quaternion.identity);
                }

              
            }
        }
    }

    void GenerateMatrix()
    {
        _mapMatrix = new int[height, width];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {

                // Calculate the Perlin noise value for this position
                float xCoord = (float)x / width * scale;
                float yCoord = (float)y / height * scale;
                float perlinValue = Mathf.PerlinNoise(xCoord, yCoord);

                
                // Threshold the Perlin noise value to 1 or 0
                if (perlinValue > 0.3f)
                {
                    _mapMatrix[y, x] = 1;
                }
                
                else
                {
                    _mapMatrix[y, x] = 0;
                }
            }
        }

        // Now 'matrix' contains your 2D matrix with values of 1 or 0 based on the Perlin noise
    }


}
