using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Orb : MonoBehaviour
{
    public List<ActiveStateSelector> poses;
    [SerializeField] GameObject orb;
    [SerializeField] GameObject orb_target;
    // Start is called before the first frame update
    void Start()
    {

        foreach (var item in poses)
        {
            item.WhenSelected += () => Shoot();
          // item.WhenUnselected += () => StopDraw();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Shoot()
    {
        Instantiate(orb, orb_target.transform.position, orb_target.transform.rotation);
    }
}
