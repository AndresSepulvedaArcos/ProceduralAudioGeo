using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Interpolations))]
public class InterpolationEditor : Editor
{

    Interpolations interpolations;

    private void OnEnable()
    {
          interpolations= (Interpolations)target;

    }

    public void OnSceneGUI()
    {
        EditorGUI.BeginChangeCheck();
        Vector3[] handlesPositions= interpolations.points;
       
            for (int i = 0; i < handlesPositions.Length; i++)
            {
               
                interpolations.points[i] = Handles.DoPositionHandle(handlesPositions[i], Quaternion.identity);
                Handles.SphereHandleCap(i, handlesPositions[i], Quaternion.identity, 0.2f, EventType.Repaint);
               
                
            }
        Handles.DrawBezier(handlesPositions[0], handlesPositions[3], handlesPositions[1], handlesPositions[2], Color.magenta, EditorGUIUtility.whiteTexture, 1);

        if (EditorGUI.EndChangeCheck())
        {
             
            for (int i = 0; i < handlesPositions.Length; i++)
            {
                
                interpolations.points[i]= handlesPositions[i];

                Undo.RecordObject(target,"changeposition"+i); 
            }
            Handles.EndGUI();


        }

    }


    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }



}
