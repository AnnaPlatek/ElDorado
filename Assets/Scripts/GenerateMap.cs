using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    public GameObject HexPrefab;

    [SerializeField] private Material[] Materials;
    int height = 10;
    int width = 10;
    float xOffset = 1.74f;
    float zOffset = 1.51f;
    int HexType;


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
                Tile_go.transform.SetParent(this.transform);
                Tile_go.name = "Tile_" + x + "_" + y;
                HexType = Random.Range(0, 4);
                Material[] matArray = Tile_go.GetComponentInChildren<MeshRenderer>().materials;

                if (HexType == 0)
                {
                    //Debug.Log("random = 0");
                    matArray[0] = Materials[0];
                    matArray[1] = Materials[3];
                    Tile_go.GetComponentInChildren<MeshRenderer>().materials = matArray;
                }
                else if (HexType == 1)
                {
                    //Debug.Log("random = 1");
                    matArray[0] = Materials[1];
                    matArray[1] = Materials[3];
                    Tile_go.GetComponentInChildren<MeshRenderer>().materials = matArray;
                }
                else if (HexType == 2)
                {
                    //Debug.Log("random = 2");
                    matArray[0] = Materials[2];
                    matArray[1] = Materials[3];
                    Tile_go.GetComponentInChildren<MeshRenderer>().materials = matArray;
                }
                else
                {
                    //Debug.Log("random = 3");
                    matArray[0] = Materials[3];
                    matArray[1] = Materials[3];
                    Tile_go.GetComponentInChildren<MeshRenderer>().materials = matArray;
                }

            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        //Prints Materials from Tile_0_0 as a debug
        //GameObject Tile_go = GameObject.Find("Tile_0_0");
        //Material[] matArray = Tile_go.GetComponentInChildren<MeshRenderer>().materials;
        //Debug.Log("second" + matArray[0] + " " + matArray[1] + " " + matArray[2]);
    }
}
