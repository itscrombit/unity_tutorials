using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Animator door;
    public GameObject openText;
    public AudioSource openSound;

    public bool inReach;
    public bool isOpen;



    void Start()
    {
        inReach = false;
        openText.SetActive(false);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            openText.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
        }
    }


    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            openSound.Play();
            door.SetBool("Open", true);
            door.SetBool("Closed", false);
            openText.SetActive(false);
            isOpen = true;
        }

        else if (inReach && Input.GetButtonDown("Interact"))
        {
            openText.SetActive(false);
        }

        if (isOpen)
        {
            door.GetComponent<BoxCollider>().enabled = false;
            door.GetComponent<DoorOpen>().enabled = false;
        }
    }
}
