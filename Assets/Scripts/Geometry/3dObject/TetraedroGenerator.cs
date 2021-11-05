using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class TetraedroGenerator : MonoBehaviour
{
    MeshRenderer meshRenderer;
    MeshFilter meshFilter;
    public List<Vector3> vertices= new List<Vector3>();
    public List<int> triangles= new List<int>();

    Mesh mesh;

    private void Awake()
    {
        meshRenderer=GetComponent<MeshRenderer>();
        meshFilter=GetComponent<MeshFilter>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected virtual void GenerateMesh()
    {
        GenerateVertices();
        GenerateTriangles();

        mesh.SetVertices(vertices);
        mesh.SetTriangles(triangles, 0);

     
        mesh.RecalculateNormals();

       meshFilter.mesh = mesh;

    }

    protected virtual void GenerateVertices()
    {

    }
    protected virtual void GenerateTriangles()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
        GenerateMesh();
        
    }
}
