using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveball : MonoBehaviour
{
    private Rigidbody rb;
   [SerializeField] float ballspeed;
   // [SerializeField] GameObject playerobject;


    // Start is called before the first frame update
    void Start()
    {
       
         rb = GetComponent<Rigidbody>();
         rb.velocity = transform.forward * ballspeed;
        //GetComponent<MeshRenderer>().enabled = false;
        //GetComponent<SphereCollider>().enabled = false;

    }

    private void OnCollisionEnter(Collision collision)
    {
       // if (collision.gameObject.CompareTag("Floor"))
       // {

            Destroy(this.gameObject,1.0f);
           

       // }

    }
 
}
