using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pose_Detector : MonoBehaviour
{
    public List<ActiveStateSelector> poses;

    private Rigidbody rb;
  //  [SerializeField] GameObject playerobject;
   // [SerializeField] GameObject transformball;
    [SerializeField] GameObject target;
   // [SerializeField] float ballspeed;
    //[SerializeField] BoxCollider floorcollider;
    [SerializeField] GameObject rayspot;
    [SerializeField] GameObject rigposition;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in poses)
        {
            item.WhenSelected += () =>teleport();
            //item.WhenUnselected += () => StopPlayer(); ;
        }
    }
    private void Update()
    {
      //  Debug.DrawRay(target.transform.position, target.transform.forward, Color.green);
    }
    private void teleport()
    {


        RaycastHit hit;
        Ray ray = new Ray(target.transform.position, target.transform.forward);
       // Debug.DrawRay(target.transform.position, target.transform.forward, Color.green);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Floor"))
            {
                rayspot.transform.position = new Vector3(hit.point.x, rigposition.transform.position.y, hit.point.z);
                rigposition.transform.position = rayspot.transform.position;
            }


        }
    }
}
