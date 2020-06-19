using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class meshgenarator : MonoBehaviour
{
    public Mesh mesh;
    [SerializeField] public Texture texture;
    Vector3[] vertices;
    Vector2[] uv;
    int[] triangles;

    void Start()
    {
        BuildMesh();
    }

    private void BuildMesh()
    {
        mesh = new Mesh(); //create new empty mesh
        GetComponent<MeshFilter>().mesh = mesh;
        CreateShape(); //generate mesh data
        UpdateMesh(); //popululate mesh with data

        MeshFilter mesh_filter = GetComponent<MeshFilter>();
        MeshRenderer mesh_renderer = GetComponent<MeshRenderer>();
        mesh_renderer.material.mainTexture = texture;
        MeshCollider mesh_collider = GetComponent<MeshCollider>();
    }

    void CreateShape()
    {
        vertices = new Vector3[]
        {
        new Vector3(-1f, 0f,-0.5f), //verticles[0]             2
        new Vector3(-1f, 0f, 0.5f), //verticles[1]        1         3
        new Vector3(0f, 0f, 1f),    //verticles[2]               
        new Vector3(1f, 0f, 0.5f),  //verticles[3]               
        new Vector3(1f, 0f, -0.5f), //verticles[4]        0         4   
        new Vector3(0f, 0f, -1f)    //verticles[5]             5
        };

        triangles = new int[]
        {
            1, 5, 0, //triagles[0], triagles[1], triagles[2]
            1, 4, 5, //triagles[3], triagles[4], triagles[5]
            1, 2, 4, //triagles[6], triagles[7], triagles[8]
            2, 3, 4  //triagles[9], triagles[10], triagles[11]
        };

        uv = new Vector2[]
        {
        new Vector2(0f, 0.25f),
        new Vector2(0f, 0.75f),
        new Vector2(0.5f, 1f),
        new Vector2(1f, 0.75f),
        new Vector2(1f, 0.25f),
        new Vector2(0.5f, 0f)
        };

    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;
        mesh.RecalculateNormals();
    }
}
