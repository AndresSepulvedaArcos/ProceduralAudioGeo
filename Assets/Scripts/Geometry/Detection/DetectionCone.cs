using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class DetectionCone : MonoBehaviour
{
    MeshRenderer meshRenderer;
    MeshFilter meshFilter;
    private List<Vector3> vertices = new List<Vector3>();
    private List<int> triangles = new List<int>();

    Mesh mesh;

    [Header("Cone settings")]
    [Range(0, 360)]
    public float angle=45;
    public float coneDistance=2f;
    [Range(3,100)]
    public int sides=3;
    int faces;
    int nVertices;




    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshFilter = GetComponent<MeshFilter>();

    }

    protected virtual void GenerateMesh()
    {
        GenerateVertices();
        GenerateTriangles();
        mesh = new Mesh();
        mesh.SetVertices(vertices);
        mesh.SetTriangles(triangles, 0);


        mesh.RecalculateNormals();

        meshFilter.mesh = mesh;

    }

    protected virtual void GenerateVertices()
    {
        vertices.Clear();
        faces=sides/3;


        Vector3 origin=Vector3.zero;
        Vector3 destination;

        float angleMod=0;
        float angleIncrement=angle/faces;
        RaycastHit hit;
        for (int i = 0; i < faces; i++)
        {

            angleMod=angleIncrement*i;
        
            for (int j = 0; j < 2; j++)
            {
                destination = Quaternion.Euler(0,  j==0?angleMod:angleMod+angleIncrement, 0) * Vector3.forward * coneDistance;
                if (Physics.Raycast(transform.TransformPoint(origin), destination, out hit))
                {

                    Debug.DrawLine(transform.TransformPoint(origin), hit.point);
                }
                else
                {
                    Debug.DrawLine(transform.TransformPoint(origin), transform.TransformPoint(destination));

                }
            }           

       
             

        }



    
    }
    protected virtual void GenerateTriangles()
    {
       triangles.Clear();



    }
    // Update is called once per frame
    void Update()
    {

        GenerateMesh();

    }
    // Start is called before the first frame update
  
}
