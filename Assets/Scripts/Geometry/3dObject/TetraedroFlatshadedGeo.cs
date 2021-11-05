using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetraedroFlatshadedGeo : TetraedroGenerator
{


    protected override void GenerateVertices()
    {
        vertices.Clear();
        vertices.Add(new Vector3(0, 0, 0));
        vertices.Add(new Vector3(0.5f, 1, 0.5f));
        vertices.Add(new Vector3(1, 0, 0));

        vertices.Add(new Vector3(1, 0, 0));
        vertices.Add(new Vector3(0.5f, 1, 0.5f));
        vertices.Add(new Vector3(0.5f, 0, 1));

        vertices.Add(new Vector3(0, 0, 0));
        vertices.Add(new Vector3(0.5f, 0, 1));
        vertices.Add(new Vector3(0.5f,1, 0.5f));

        vertices.Add(new Vector3(0, 0, 0));
        vertices.Add(new Vector3(1, 0,0));
        vertices.Add(new Vector3(0.5f, 0,1));





    }

    protected override void GenerateTriangles()
    {
        triangles.Clear();

        triangles.Add(0);
        triangles.Add(1);
        triangles.Add(2);

        triangles.Add(3);
        triangles.Add(4);
        triangles.Add(5);

        triangles.Add(6);
        triangles.Add(7);
        triangles.Add(8);

        triangles.Add(9);
        triangles.Add(10);
        triangles.Add(11);
    }
}
