using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stay_by_player : MonoBehaviour
{
    [SerializeField] GameObject playerobject;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(playerobject.transform.position.x, playerobject.transform.position.y, playerobject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerobject.transform.position.x, playerobject.transform.position.y, playerobject.transform.position.z);
    }
}
