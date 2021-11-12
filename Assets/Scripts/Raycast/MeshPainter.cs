using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshPainter : MonoBehaviour
{
    public Color[] colors;
    public void PaintVertexHit(RaycastHit hit)
    {

     Mesh mesh=   GetComponent<MeshFilter>().sharedMesh;
      colors=mesh.colors;
       
        colors[mesh.triangles[hit.triangleIndex]]=Color.blue;
        colors[mesh.triangles[hit.triangleIndex+1]] = Color.blue;
        colors[mesh.triangles[hit.triangleIndex+2]] = Color.blue;

        GetComponent<MeshFilter>().sharedMesh.SetColors(colors);


    }

}
