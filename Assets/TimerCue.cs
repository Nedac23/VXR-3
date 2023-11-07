using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerCue : MonoBehaviour
{
    [SerializeField] float remainingTime;
    private GameObject window;
    private BreakableWindow bool_script;
    private GameObject AlarmLight;
    [SerializeField] AudioSource Nuke;
    [SerializeField] AudioSource Music;
    private GameObject exitTrigger;
    private AudioSource alarmaudio;
    public bool stoppedAudio = false;
    private bool nukeExploded = false;
    private GameObject blob;

    void Start()
    {
        window = GameObject.FindWithTag("Window");
        AlarmLight = GameObject.FindWithTag("AlarmLights");
        bool_script = window.GetComponent<BreakableWindow>();
        exitTrigger = GameObject.FindWithTag("Exit");
        alarmaudio = AlarmLight.GetComponent<AudioSource>();
        blob = GameObject.FindWithTag("blob");
        blob.GetComponent<MeshRenderer>().enabled = false;


    }

    void Update()
    {
        if (bool_script.windowBreak == true)
        {
            remainingTime -= Time.deltaTime;
        }

        if (remainingTime < 15)
        {
            stoppedAudio = true;
            alarmaudio.Pause();
            if(Music.isPlaying == false)
            {
                Music.Play();
            }
            
        }

        if (remainingTime < 1)
        {
            exitTrigger.GetComponent<PlayerExits>().enabled = false;
            if (Nuke.isPlaying == false && nukeExploded == false)
            {
                nukeExploded = true;
                Nuke.Play();
                //GameObject.Find("Cube").GetComponent().enabled = false;
                // blob.GetComponent().enabled = true;
                blob.GetComponent<MeshRenderer>().enabled = true;
            }
        }
        
    }
}
