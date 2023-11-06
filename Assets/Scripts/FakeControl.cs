using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeControl : MonoBehaviour
{
    public Transform actualCont;
    public Transform fakeCont;

    // Update is called once per frame
    void Update()
    {
        fakeCont.position = actualCont.position;
        fakeCont.rotation = actualCont.rotation;
    }
}