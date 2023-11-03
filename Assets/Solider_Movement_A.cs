using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solider_Movement_A : MonoBehaviour
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

        if (death == false)
        {

            //Moves the empty game object target to the position of the Head objecty with a Y similar to the NPC to avoid odd rotations
            target.transform.position = new Vector3(head.transform.position.x, 1, head.transform.position.z);

            if (Vector3.Distance(transform.position, target.transform.position) < followdistance)
            {

                turn = true;
                //zero Y vector
                Vector3 targetDirection = target.transform.position - transform.position;

                //Rotation
                //speed variable
                float singleStep = Rotationspeed * Time.deltaTime;
                //new direction vector to rotate to
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
                //drawws ray in direction of new vector
                Debug.DrawRay(transform.position, newDirection, Color.red);
                //rotates object/NPC
                transform.rotation = Quaternion.LookRotation(newDirection);

                //Raycasting
                RaycastHit hit;
                Ray ray = new Ray(transform.position, transform.forward);
                Debug.DrawRay(transform.position, transform.forward, Color.green);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider == playercollider)
                    {
                        // Debug.Log("Ray hit player");
                        if (Vector3.Distance(transform.position, target.transform.position) < attackdistance)
                        {
                            anim.SetBool("Aiming", true);
                           
                        }

                    }
                    
                }
                
            }

            else
            {
                anim.SetBool("Aiming", false);
                turn = false;
            }
            if (anim.GetBool("Aiming") == false && turn == false)
            {



                WaypointFollower2();
            }
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
    private void WaypointFollower2()
    {

        if (Vector3.Distance(transform.position, waypoints[waypointIndex].transform.position) < .1f)
        {

            waypointIndex++;

            if (waypointIndex >= (waypoints.Length))
            {
                waypointIndex = 0;

            }

        }
        Vector3 targetDirection = waypoints[waypointIndex].transform.position - transform.position;
        float singleStep = Rotationspeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        Debug.DrawRay(transform.position, newDirection, Color.red);
        transform.rotation = Quaternion.LookRotation(newDirection);


        //Moves Enemy with Rigid Body to stop going through walls
        Vector3 movePosition = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, speed * Time.deltaTime);
        rb.MovePosition(movePosition);
    }
}