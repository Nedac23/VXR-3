using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRay : MonoBehaviour
{
    public List<ActiveStateSelector> poses;

    [SerializeField] BoxCollider floorcollider;
    [SerializeField] GameObject target;
    [SerializeField] GameObject rayspot;
    [SerializeField] GameObject Icon;
    [SerializeField] GameObject LineRenderer;


    // Start is called before the first frame update
    void Start()
    {
        
        foreach (var item in poses)
        {
            item.WhenSelected += () => Drawray();
            item.WhenUnselected += () => StopDraw();
        }
        
    }
    private void Update()
    {
        /*
        //Debug.DrawRay(target.transform.position, target.transform.forward, Color.green);
        RaycastHit hit;
        Ray ray = new Ray(target.transform.position, target.transform.forward);
        // Debug.DrawRay(target.transform.position, target.transform.forward, Color.green);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider == floorcollider)
            {
                Icon.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                
            }


        }
        */

    }
    private void Drawray()
     {
        /*
         //Debug.DrawRay(target.transform.position, target.transform.forward, Color.green);
         RaycastHit hit;
         Ray ray = new Ray(target.transform.position, target.transform.forward);
         // Debug.DrawRay(target.transform.position, target.transform.forward, Color.green);
         if (Physics.Raycast(ray, out hit))
         {
             if (hit.collider == floorcollider)
             {
                Icon.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                
             }


         }
        */


        LineRenderer.GetComponent<LineRenderer>().enabled = true;
     }
    private void StopDraw()
    {
        LineRenderer.GetComponent<LineRenderer>().enabled = false;
    }
}