using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poseteleport : MonoBehaviour
{
    public List<ActiveStateSelector> poses;

    [SerializeField] GameObject playerobject;

    [SerializeField] GameObject[] waypoints;
    int waypointIndex = 0;
    // Start is called before the first frame update
   /* void Start()
    {
        foreach (var item in poses)
        {
            item.WhenSelected += () => MovePlayer();
            waypointIndex++;
            if(waypointIndex >= waypoints.Length)
            {
                waypointIndex = 0;
            }
            //item.WhenUnselected += () => StopPlayer(); ;
        }
    }
   */
    private void Update()
    {
        foreach (var item in poses)
        {
            item.WhenSelected += () => MovePlayer();
            waypointIndex++;
            if (waypointIndex >= waypoints.Length)
            {
                waypointIndex = 0;
            }
            //item.WhenUnselected += () => StopPlayer(); ;
        }
    }
    private void MovePlayer()
    {
        playerobject.transform.position = new Vector3(waypoints[waypointIndex].transform.position.x, playerobject.transform.position.y, waypoints[waypointIndex].transform.position.z);

    }
}
