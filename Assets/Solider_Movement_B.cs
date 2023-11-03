using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solider_Movement_B : MonoBehaviour
{
    //Other than unity asset store    Turbo Squid   Sketch Fab
    [SerializeField] GameObject[] waypoints;
    [SerializeField] GameObject target;
    [SerializeField] GameObject head;
    int waypointIndex = 0;
    [SerializeField] float speed = 1f;
    [SerializeField] float Rotationspeed = 1f;
    [SerializeField] float attackdistance = .1f;
    [SerializeField] float followdistance = .5f;
    bool stand = false;
    private Animator anim;
    private CapsuleCollider coll;
    bool turn = false;
    bool death = false;
    private Rigidbody rb;
    [SerializeField] BoxCollider playercollider;
    [SerializeField] AudioSource Deathsound;
    [SerializeField] int Hitpoints;
    private int hitcount = 0;
    [SerializeField] CapsuleCollider weaponcoll;
    [SerializeField] float waittime;
    private float numupdate = 0;
    bool GlassBroken = false;


    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<CapsuleCollider>();
        weaponcoll = GetComponent<CapsuleCollider>();
        //anim.SetBool("Die", true);

    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        Physics.Linecast(transform.position, head.transform.position, out hit);
        Debug.DrawLine(transform.position, head.transform.position);
        //Ray ray = new Ray(transform.position, head.transform.position);
        //Debug.DrawRay(transform.position, head.transform.position, Color.green);



            if (hit.collider == playercollider && GlassBroken == false)
            {
                GlassBroken = true;
            anim.SetBool("Glass", true);
            WaypointFollower();
            }
            else if(GlassBroken == true)
            {
                WaypointFollower();
            }
        


    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fireball"))
        {
            hitcount++;
            if (hitcount >= Hitpoints)
            {
                weaponcoll.enabled = false;
                anim.SetBool("Die", true);
                death = true;
                coll.enabled = false;

                Deathsound.PlayDelayed(0);
            }

        }

    }
    private void WaypointFollower()
    {

        if (Vector3.Distance(transform.position, waypoints[waypointIndex].transform.position) < .1f)
        {

            waypointIndex++;
            //anim.SetTrigger("idle");
            //bool idelstate = anim.GetBool("idle");
            //idelstate = true;
            // transform.Rotate(0, 180, 0);
            if (waypointIndex >= (waypoints.Length))
            {
                Destroy(this.gameObject);
                waypointIndex = 0;

            }
            //idelstate = false;
        }
        Vector3 targetDirection = waypoints[waypointIndex].transform.position - transform.position;
        float singleStep = Rotationspeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        Debug.DrawRay(transform.position, newDirection, Color.red);
        transform.rotation = Quaternion.LookRotation(newDirection);

        //Old movement that allows going through walls
        //transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, speed * Time.deltaTime);
        //rb.MovePosition(transform.position);

        //Moves Enemy with Rigid Body to stop going through walls
        Vector3 movePosition = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, speed * Time.deltaTime);
        rb.MovePosition(movePosition);
    }
}
