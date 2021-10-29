using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class GenerateCircleGon : MonoBehaviour
{
    public List<Vector3> vertices = new List<Vector3>();
    List<int> triangles = new List<int>();
    public int sides=3;
    public float radius=1;
    Mesh mesh;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        GenerateVertices();
        GenerateTriangles();
        GenerateMesh();
    }

  
    void GenerateVertices()
    {
        vertices.Clear();
        for (int i = 0; i < sides; i++)
        {
               float angle= 2*Mathf.PI* ((float)i/ (float)sides);
                Vector3 position=new Vector3(radius* Mathf.Cos(angle),radius*Mathf.Sin(angle),0);
                vertices.Add(position);


        }
    }

    void GenerateTriangles()
    {
        triangles.Clear();
        for (int i = 1; i < sides-1; i++)
        {
            triangles.Add(0);
            triangles.Add(i+1);
            triangles.Add(i);

        }

    }
    void GenerateMesh()
    {
        mesh = new Mesh();
        mesh.SetVertices(vertices);
       

        mesh.SetTriangles(triangles, 0);
        mesh.RecalculateNormals();
        GetComponent<MeshFilter>().mesh = mesh;



    }
}
