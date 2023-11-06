using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick_Despawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("should delete");
        if (collision.gameObject.CompareTag("Brick"))
        {
            //Debug.Log("should delete");
            Destroy(collision.gameObject, 2);
           
        

        }

    }

}
