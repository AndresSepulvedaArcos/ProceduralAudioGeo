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
        if(Physics.Raycast(ray,out hit))
        {
             
            hit.transform.GetComponent<MeshPainter>()?.PaintVertexHit(hit);


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
