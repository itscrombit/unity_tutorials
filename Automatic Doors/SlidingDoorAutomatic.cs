using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoorAutomatic : MonoBehaviour
{
    public Animator door;
    public AudioSource openSound;
    public AudioSource closeSound;

    public bool inReach;
    public bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        isOpen = false;
        openSound.Stop();
        closeSound.Stop();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach2")
        {
            inReach = true;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach2")
        {
            inReach = false;
           
        }
    }

    // Update is called once per frame
    void Update()
    { 
        if (inReach == true && isOpen == false)
        {
            door.SetBool("Open", true);
            door.SetBool("Closed", false);
            openSound.Play();
            isOpen = true;
        }
        if (inReach == false && isOpen == true)
        {
            door.SetBool("Open", false);
            door.SetBool("Closed", true);
            closeSound.Play();
            isOpen = false;
        }

    }
}
