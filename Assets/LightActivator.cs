using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightActivator : MonoBehaviour
{
    private GameObject window;
    private BreakableWindow bool_script;

    // Start is called before the first frame update
    void Start()
    {
        //bool_script.windowBreak = false;
        window = GameObject.FindWithTag("Window");
        bool_script = window.GetComponent<BreakableWindow>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bool_script.windowBreak == true)
        {
            GetComponent<Light>().enabled = true;
            GetComponent<Animator>().enabled = true;
            GetComponent<AudioSource>().Play();
            bool_script.windowBreak = false;
        }
    }
}
