using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExits : MonoBehaviour
{
    private Timer timer_script;
    private GameObject timerObject;
    // Start is called before the first frame update
    void Start()
    {
        timerObject = GameObject.FindWithTag("TV");
        timer_script = timerObject.GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PowerObject"))
        {
            timer_script.enabled = false;
        }
    }
}
