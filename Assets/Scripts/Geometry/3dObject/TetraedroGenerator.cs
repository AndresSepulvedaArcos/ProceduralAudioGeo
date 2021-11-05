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
    public float normalDisplaySize=2;

    private void Awake()
    {
        meshRenderer=GetComponent<MeshRenderer>();
        meshFilter=GetComponent<MeshFilter>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnDrawGizmosSelected()
    {

        for (int i = 0; i < vertices.Count; i++)
        {
            Vector3 startPosition=transform.TransformPoint( vertices[i]);
            Vector3 endPosition= startPosition+(mesh.normals[i]* normalDisplaySize);

            Gizmos.DrawLine(startPosition,endPosition);
        }
    }

    protected virtual void GenerateMesh()
    {
        GenerateVertices();
        GenerateTriangles();
        mesh=new Mesh();
        mesh.SetVertices(vertices);
        mesh.SetTriangles(triangles, 0);

     
        mesh.RecalculateNormals();

       meshFilter.mesh = mesh;

    }

    protected virtual void GenerateVertices()
    {

        vertices.Clear();
        vertices.Add(new Vector3(0,0,0));
        vertices.Add(new Vector3(0.5f, 1, 0.5f));
        vertices.Add(new Vector3(1, 0,0));
        vertices.Add(new Vector3(.5f, 0, 1));
    }
    protected virtual void GenerateTriangles()
    {
        triangles.Clear();
            
        triangles.Add(0);
        triangles.Add(1);
        triangles.Add(2);

        triangles.Add(2);
        triangles.Add(1);
        triangles.Add(3);

        triangles.Add(3);
        triangles.Add(1);
        triangles.Add(0);

        triangles.Add(0);
        triangles.Add(2);
        triangles.Add(3);

    }
    // Update is called once per frame
    void Update()
    {
        
        GenerateMesh();
        
    }
}
