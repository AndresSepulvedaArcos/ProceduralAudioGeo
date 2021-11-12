using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSRaycast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void ShootRay()
    {
       Ray ray= Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        Debug.DrawLine(ray.origin,ray.direction*100,Color.red);
     // GetComponent<LineRenderer>().SetPosition(0,ray.origin);
       // GetComponent<LineRenderer>().SetPosition(1, ray.origin+ ray.direction * 100);
        
        if (Physics.Raycast(ray,out hit))
        {
             
            hit.transform.GetComponent<MeshPainter>()?.PaintVertexHit(hit,ray);


        }else
        {
            Debug.Log("hit nothing");

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            ShootRay();
        
    }
}
