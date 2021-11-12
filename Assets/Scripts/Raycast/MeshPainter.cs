using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshPainter : MonoBehaviour
{
    public Color[] colors;
   public Vector3[] vertices;
    public void PaintVertexHit(RaycastHit hit,Ray ray)
    {

     Mesh mesh=   GetComponent<MeshFilter>().sharedMesh;
      colors=mesh.colors;

       vertices= mesh.vertices;



        //mesh.triangles[hit.triangleIndex * 3+0] indice trinagulo  para el vertice 1
        //mesh.triangles[hit.triangleIndex * 3+1] indice triangulo para el vertice 2
        //mesh.triangles[hit.triangleIndex * 3+2] indice trinagulo para eñ vertice 3
        for (int i = 0; i < 3; i++)
        {
            Vector3 vertexPosition = vertices[mesh.triangles[hit.triangleIndex * 3 + i]];
            Vector3 impactDirection=(vertexPosition-transform.InverseTransformPoint(ray.origin)).normalized;

            vertices[mesh.triangles[hit.triangleIndex * 3+i]] += impactDirection*.1f;

        }
           
            

        /* colors[mesh.triangles[hit.triangleIndex*3]]=Color.blue;
         colors[mesh.triangles[hit.triangleIndex*3+1]] = Color.blue;
         colors[mesh.triangles[hit.triangleIndex*3+2]] = Color.blue;

         GetComponent<MeshFilter>().sharedMesh.SetColors(colors);

     */
     GetComponent<MeshFilter>().sharedMesh.SetVertices(vertices);
      GetComponent<MeshFilter>().sharedMesh.RecalculateNormals();
    }

}
