using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExits : MonoBehaviour
{
    private Timer timer_script;
    private GameObject timerObject;
    private GameObject timerCue;
    private TimerCue timerCue_script;
    private GameObject alarmLight;
    private AudioSource alarmAudio;
    // Start is called before the first frame update
    void Start()
    {
        timerObject = GameObject.FindWithTag("TV");
        timerCue = GameObject.FindWithTag("TimerCue");
        alarmLight = GameObject.FindWithTag("AlarmParent");
        timer_script = timerObject.GetComponent<Timer>();
        timerCue_script = timerCue.GetComponent<TimerCue>();
        alarmAudio = alarmLight.GetComponent<AudioSource>();

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
            timerCue_script.enabled = false;
            //alarmLight.SetActive(false);
            /*alarmAudio.Pause();
            alarmLight.GetComponent<Light>().enabled = false;
            alarmLight.GetComponent<Animator>().enabled = false;*/
            //this.SetActive(false);
        }
    }
}
