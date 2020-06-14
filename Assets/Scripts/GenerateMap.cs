using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    public GameObject HexPrefab;

    int height = 10;
    int width = 10;
    float xOffset = 1.74f;
    float zOffset = 1.51f;

    void Start()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y =0; y < height; y++)
            {
                float xPos = x * xOffset;

                if ( y %2 == 1)
                {
                    xPos += xOffset / 2f;
                }

                GameObject Tile_go = (GameObject)Instantiate(HexPrefab, new Vector3(xPos, 0, y * zOffset), Quaternion.identity);

                Tile_go.name = "Tile_" + x + "_" + y;
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
