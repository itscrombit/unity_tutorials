using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Animator timer;
    public GameObject Outside;
    public GameObject Inside;
    public AudioSource timerAudio;
    public AudioSource tenSecAudio;

    public bool inReach;

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

    // Start is called before the first frame update
    void Start()
    {
        Outside.SetActive(false);
        Inside.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inReach)
        {
            Outside.SetActive(true);
            Inside.SetActive(true);
            timer.SetBool("Start", true);
            timerAudio.Play();
            StartCoroutine(TimerEnd());
        }
    }

    IEnumerator TimerEnd()
    {
        yield return new WaitForSeconds(50);
        timerAudio.Stop();
        tenSecAudio.Play();
    }
}
