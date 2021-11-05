using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class GenerateQuad : MonoBehaviour
{
    public List<Vector3> vertices = new List<Vector3>();
    public Vector2[] uvs=new Vector2[4];


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GenerateUV();
        GenerateMesh();
    }
    void GenerateUV()
    {

        for (int i = 0; i < vertices.Count; i++)
        {
            uvs[i] = vertices[i];

        }

    }
    void GenerateMesh()
    { 
        Mesh mesh = new Mesh();
        mesh.SetVertices(vertices);
        List<int> triangles = new List<int>()
        {
            0,1,3,1,2,3
        };

        mesh.SetTriangles(triangles, 0);

        mesh.SetUVs(0,uvs);

        mesh.RecalculateNormals();
       
        GetComponent<MeshFilter>().mesh = mesh;



    }


}
