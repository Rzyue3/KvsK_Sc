using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var mouse = Input.mousePosition;
        var target = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, 10f));
        this.transform.position = new Vector3(target.x,0f,target.z);
        
/*
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hit = new RaycastHit();
        if(Physics.Raycast(ray, out hit))
        {
            this.transform.position = new Vector3(hit.point.x,0f,hit.point.z);

        }     
*/
    }
}
