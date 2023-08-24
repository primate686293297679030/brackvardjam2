using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int width = 100;
    public int height = 100;
    public float scale = 10f;

    public GameObject prefab;

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
                if (_mapMatrix[y, x] == 1)
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
