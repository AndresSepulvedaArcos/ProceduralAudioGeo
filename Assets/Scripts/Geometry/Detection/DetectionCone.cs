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
    public List<Vector3> vertices = new List<Vector3>();
    public List<int> triangles = new List<int>();

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
        Debug.Log(angleIncrement);
        RaycastHit hit;
        vertices.Add(Vector3.zero);
        for (int i = 0; i < faces; i++)
        {

            angleMod=angleIncrement*i;
        
            for (int j = 0; j < 2; j++)
            {
                destination = Quaternion.Euler(0,  j==0?angleMod:angleMod+angleIncrement, 0) * Vector3.forward ;
                if (Physics.Raycast(transform.TransformPoint(origin), transform.TransformDirection(destination.normalized)  , out hit,coneDistance))
                {
                    vertices.Add(transform.InverseTransformPoint(hit.point));
                    Debug.DrawLine(transform.TransformPoint(origin), hit.point);
                }
                else
                {
                    vertices.Add(destination);

                    Debug.DrawLine(transform.TransformPoint(origin), transform.TransformPoint(destination));

                }
            }           

       
             

        }



    
    }
    protected virtual void GenerateTriangles()
    {
       triangles.Clear();

        for (int i = 1; i <= faces; i++)
        {
            triangles.Add(0);
            triangles.Add(i);
            triangles.Add(i+1);

        }



    }
    // Update is called once per frame
    void Update()
    {

        GenerateMesh();

    }
    // Start is called before the first frame update
  
}
