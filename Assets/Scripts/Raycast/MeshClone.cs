using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class MeshClone : MonoBehaviour
{
    MeshRenderer meshRenderer;
    MeshFilter meshFilter;
    public List<Vector3> vertices = new List<Vector3>();
    public List<int> triangles = new List<int>();

    Mesh mesh;
    public Mesh meshReference;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshFilter = GetComponent<MeshFilter>();

    }

    void CloneMesh()
    {
        if(meshReference==null)return;
        vertices.Clear();
        triangles.Clear();

        vertices.AddRange(meshReference.vertices);
        triangles.AddRange(meshReference.triangles);

        Color[] vertexColors= new Color[vertices.Count];

        for (int i = 0; i < vertexColors.Length; i++)
        {
           
            vertexColors[i]= Color.white;
        }


        mesh = new Mesh();
        mesh.SetVertices(vertices);
        mesh.SetTriangles(triangles, 0);
        mesh.SetColors(vertexColors);




        mesh.RecalculateNormals();

        meshFilter.mesh = mesh;


    }

    private void Update()
    {
        CloneMesh();
    }



}
