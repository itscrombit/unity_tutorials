using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFade : MonoBehaviour
{
    public Animator TextAnim;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fading());
    }

    IEnumerator Fading()
    {
        yield return new WaitForSeconds(3);
        
        TextAnim.SetBool("TextFade", true);
        TextAnim.SetBool("TextFadeOut", false);

        yield return new WaitForSeconds(3);

        TextAnim.SetBool("TextFade", false);
        TextAnim.SetBool("TextFadeOut", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
