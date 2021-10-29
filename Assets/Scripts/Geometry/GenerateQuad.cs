using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class GenerateQuad : MonoBehaviour
{
    public List<Vector3> vertices = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GenerateMesh();
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
        mesh.RecalculateNormals();
        GetComponent<MeshFilter>().mesh = mesh;



    }
}
