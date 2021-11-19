using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
 

public class Interpolations : MonoBehaviour
{
    public Vector3[] points;
    [Range(0,1f)]
    public float t;


    /*
    private void OnDrawGizmos()
    {
        if(points.Length<4)return;

        for (int i = 0; i < points.Length; i++)
        {
            Gizmos.color=Color.green;
            Gizmos.DrawSphere(points[i],1f);

        }
        Vector3 lerpPosition=CubicLerp(points[0], points[1], points[2], points[3], t);
        Gizmos.color=Color.red;
        Gizmos.DrawSphere(lerpPosition,1);

         Handles.DrawBezier(points[0], points[3], points[1], points[2],Color.magenta,EditorGUIUtility.whiteTexture,1);

    }
    */
    public Vector3 QuadraticLerp(Vector3 p0,Vector3 p1,Vector3 p2,float t)
    {
        Vector3 p01=Vector3.Lerp(p0,p1,t);
        Vector3 p12=Vector3.Lerp(p1,p2,t);
        return Vector3.Lerp(p01,p12,t);
    }
    public Vector3 CubicLerp(Vector3 A,Vector3 B,Vector3 C,Vector3 D,float t)
    {
        Vector3 AB=QuadraticLerp(A,B,C,t);
        Vector3 BC=QuadraticLerp(B,C,D,t);

        return Vector3.Lerp(AB,BC,t);

    }
}
