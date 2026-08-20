using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoorTrigger : MonoBehaviour
{
    public Animator door;
    public AudioSource openSound;
    public AudioSource closeSound;

    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        openSound.Stop();
        closeSound.Stop();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach2")
        {
            if (!isOpen)
            {
                door.SetTrigger("Open");
                openSound.Play();
                isOpen = true;
            }

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach2")
        {
            if (isOpen)
            {
                door.SetTrigger("Close");
                closeSound.Play();
                isOpen = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    { 
    }
}
