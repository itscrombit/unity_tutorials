using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    public float mousespeed = 100f;
    float yRotation = 0f;
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X") * mousespeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mousespeed * Time.deltaTime;

        yRotation -= mouseX;
        yRotation = Mathf.Clamp(yRotation, -45, 45);
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, 0, 20);
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
