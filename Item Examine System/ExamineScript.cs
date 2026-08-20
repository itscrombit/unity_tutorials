using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ExamineScript : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject examineCamera;
    public GameObject Hud;
    public Behaviour player;
    public Light Examinelight;

    public GameObject InteractText;
    public GameObject ExamineUI;
    public bool inReach;
    public bool isExaming;

    public Transform target;
    public float speedy;
    public float speedx;
    private float rootx;
    private float rooty;

    [Header("Unique")]
    public GameObject ExamineObject;
    public GameObject keyOB;
    public GameObject invOB;
    public GameObject aboutText;
    public AudioSource keySound;

    void Start()
    {
        Examinelight.enabled = false;
        invOB.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            InteractText.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            InteractText.SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(inReach && Input.GetButtonDown("Interact"))
        {
            mainCamera.SetActive(false);
            examineCamera.SetActive(true);
            isExaming = true;
            player.GetComponent<FirstPersonController>().enabled = false;
            InteractText.SetActive(false);
            ExamineUI.SetActive(true);
            Hud.SetActive(false);
            ExamineObject.SetActive(true);
            Examinelight.enabled = true;
            aboutText.SetActive(true);
            Time.timeScale = 0;
        }

        if (isExaming == true && Input.GetMouseButton(0))
        {
            rooty += Input.GetAxis("Mouse Y") * speedy;
            rootx += Input.GetAxis("Mouse X") * speedx;
            rooty = Mathf.Clamp(rooty, -360, 360);
        }
        target.eulerAngles = new Vector3(rooty, -rootx, 0);

        if (isExaming == true && Input.GetButtonDown("Escape"))
        {
            examineCamera.SetActive(false);
            mainCamera.SetActive(true);
            isExaming = false;
            player.GetComponent<FirstPersonController>().enabled = true;
            ExamineUI.SetActive(false);
            Hud.SetActive(true);
            ExamineObject.SetActive(false);
            Examinelight.enabled = false;
            aboutText.SetActive(false);
            Time.timeScale = 1;
        }

        if (isExaming == true && Input.GetMouseButton(1))
        {
            examineCamera.SetActive(false);
            mainCamera.SetActive(true);
            isExaming = false;
            player.GetComponent<FirstPersonController>().enabled = true;
            ExamineUI.SetActive(false);
            Hud.SetActive(true);
            ExamineObject.SetActive(false);
            keyOB.SetActive(false);
            keySound.Play();
            invOB.SetActive(true);
            Examinelight.enabled = false;
            aboutText.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
