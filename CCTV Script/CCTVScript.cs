using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTVScript : MonoBehaviour
{
    public GameObject UI;
    public GameObject TexttoAppear;
    public GameObject crosshair;

    public GameObject mainCam;
    public GameObject cctvCam;

    public Behaviour playerScript;

    private bool inReach;
    private bool inCam;

    // Start is called before the first frame update
    void Start()
    {
        UI.SetActive(false);
        mainCam.SetActive(true);
        cctvCam.SetActive(false);
        inCam = false;
        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            TexttoAppear.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            TexttoAppear.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            mainCam.SetActive(false);
            cctvCam.SetActive(true);
            UI.SetActive(true);
            playerScript.enabled = false;
            inCam = true;
            TexttoAppear.SetActive(false);
            crosshair.SetActive(false);
        }

        if (inCam == true && Input.GetButtonDown("Escape"))
        {
            mainCam.SetActive(true);
            cctvCam.SetActive(false);
            UI.SetActive(false);
            playerScript.enabled = true;
            inCam = false;
            TexttoAppear.SetActive(false);
            crosshair.SetActive(true);
        }
    }
}
