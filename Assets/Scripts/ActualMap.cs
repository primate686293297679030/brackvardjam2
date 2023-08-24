using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualMap : MonoBehaviour
{

    public BiomePreset[] biomes;
    public GameObject tilePrefab;

    [Header("Dimensions")]
    public int width = 50;
    public int height = 50;
    public float scale = 1.0f;
    public Vector2 offset;


    [Header("Height Map")]
    public Wave[] heightWaves;
    public float[,] heightMap;
    [Header("Moisture Map")]
    public Wave[] moistureWaves;
    private float[,] moistureMap;
    [Header("Heat Map")]
    public Wave[] heatWaves;
    private float[,] heatMap;
    public GameObject parent;

    void GenerateMap()
    {
        // height map
        heightMap = Wave.Generate(width, height, scale, heightWaves, offset);
        // moisture map
        moistureMap = Wave.Generate(width, height, scale, moistureWaves, offset);
        // heat map
        heatMap = Wave.Generate(width, height, scale, heatWaves, offset);
        for (int x = 0; x < width; ++x)
        {
            for (int y = 0; y < height; ++y)
            {
                var pos = new Vector3(x*0.2f, -y*0.2f, 0);


                GameObject tile = Instantiate(tilePrefab,parent.transform.position+pos , Quaternion.identity);
                tile.GetComponent<SpriteRenderer>().sprite = GetBiome(heightMap[x, y], moistureMap[x, y], heatMap[x, y]).GetTleSprite();
                tile.AddComponent<BoxCollider2D>();

                // tile.GetComponent<BoxCollider2D>().size
            }
        }
    }

    private BiomePreset sickBiome;
    BiomePreset GetBiome(float height, float moisture, float heat)
    {
        List<BiomeTempData> biomeTemp = new List<BiomeTempData>();
        foreach (BiomePreset biome in biomes)
        {
            if (biome.MatchCondition(height, moisture, heat))
            {
                biomeTemp.Add(new BiomeTempData(biome));
            }

        }
        float curVal = 0.0f;
        foreach (BiomeTempData biome in biomeTemp)
        {
            if (sickBiome == null)
            {
                sickBiome = biome.biome;
                curVal = biome.GetDiffValue(height, moisture, heat);
            }
            else
            {
                if (biome.GetDiffValue(height, moisture, heat) < curVal)
                {
                    sickBiome = biome.biome;
                    curVal = biome.GetDiffValue(height, moisture, heat);
                }
            }
        }
        if (sickBiome == null)
            sickBiome = biomes[0];
        return sickBiome;
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
   


}

public class BiomeTempData
{
    public BiomePreset biome;
    public BiomeTempData(BiomePreset preset)
    {
        biome = preset;
    }

    public float GetDiffValue(float height, float moisture, float heat)
    {
        return (height - biome.minHeight) + (moisture - biome.minMoisture) + (heat - biome.minHeat);
    }

   
}
