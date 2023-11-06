using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmTimerActivator : MonoBehaviour
{
    private GameObject window;
    private BreakableWindow bool_script;

    // Start is called before the first frame update
    void Start()
    {
        window = GameObject.FindWithTag("Window");
        bool_script = window.GetComponent<BreakableWindow>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bool_script.windowBreak == true)
        {
            GetComponent<Timer>().enabled = true;
        }
    }
}
