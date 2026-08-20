using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSlam : MonoBehaviour
{
    public AudioSource doorClose;
    public Animator door;
    public Behaviour Script;

    bool inReach;
    bool slammed;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach2")
        {
            inReach = true;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(inReach)
        {
            door.SetBool("Open", false);
            door.SetBool("Closed", true);
            doorClose.Play();
            slammed = true;
        }

        if(slammed == true)
        {
            Script.GetComponent<BoxCollider>().enabled = false;
            Script.enabled = false;
        }
    }
}
